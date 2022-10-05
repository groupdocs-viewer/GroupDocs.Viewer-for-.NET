import { Component, ChangeDetectorRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ViewerAppComponent, ViewerService, ViewerConfigService } from '@groupdocs.examples.angular/viewer';
import { Api, ConfigService, ModalService, UploadFilesService, NavigateService, ZoomService, PagePreloadService, RenderPrintService, PasswordService, WindowService, LoadingMaskService, PageModel, TypedFileCredentials } from '@groupdocs.examples.angular/common-components';

import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.less', './variables.less']
})
export class AppComponent extends ViewerAppComponent {

    configService: ConfigService;
    viewerService: ViewerService;
    pagesLoading: number[];
    http: HttpClient;

    constructor(viewerService: ViewerService,
        modalService: ModalService,
        viewerConfigService: ViewerConfigService,
        uploadFilesService: UploadFilesService,
        navigateService: NavigateService,
        zoomService: ZoomService,
        pagePreloadService: PagePreloadService,
        renderPrintService: RenderPrintService,
        passwordService: PasswordService,
        windowService: WindowService,
        loadingMaskService: LoadingMaskService,
        http: HttpClient,
        configService: ConfigService,
        cdr: ChangeDetectorRef,
        translate: TranslateService) {

        super(viewerService,
            modalService,
            viewerConfigService,
            uploadFilesService,
            navigateService,
            zoomService,
            pagePreloadService,
            renderPrintService,
            passwordService,
            windowService,
            loadingMaskService,
            cdr,
            translate);

        this.configService = configService;
        this.viewerService = viewerService;
        this.pagesLoading = [];
        this.http = http;
    }

    preloadPages(start: number, end: number) {
        const pagesToLoad = [];
        const isInitialLoad = start === 1;
        const minPagesToLoad = this.viewerConfig.preloadPageCount;
        const countPages = this.file.pages.length;
        this.selectedPageNumber = 1;
        
        if (isInitialLoad) {
            this.pagesLoading = [];
        }
        
        for (let i = start; i <= end; i++) {
            const page = this.file.pages.find(p => p.number === i);
            if(page && page.data) {
                continue;
            }
            
            if (this.pagesLoading.indexOf(i) === -1) {
                this.pagesLoading.push(i);
                pagesToLoad.push(i);
            }
        }

        if (pagesToLoad.length > 0) {
            const last = pagesToLoad[pagesToLoad.length - 1];
            if (!isInitialLoad && pagesToLoad.length < minPagesToLoad) {
                const addPages = minPagesToLoad - pagesToLoad.length;
                for (let i = last; i < last + addPages; i++) {
                    const pageNumber = i + 1;

                    if (pageNumber <= countPages && this.pagesLoading.indexOf(pageNumber) === -1) {
                        pagesToLoad.push(pageNumber);
                        this.pagesLoading.push(pageNumber);
                    }
                }
            }

            this.loadPages(this.credentials, pagesToLoad).subscribe((
                (pages: any) => {
                    pages.forEach((page: PageModel) => {
                        const pageIndex = page.number - 1;
                        const currPage = this.file.pages[pageIndex];

                        if (currPage) {
                            currPage.data = page.data;
                            if (this.file.thumbnails[pageIndex]) {
                                this.file.thumbnails[pageIndex].data = page.data;
                                this.file.thumbnails[pageIndex].width = currPage.width;
                                this.file.thumbnails[pageIndex].height = currPage.height;
                            }
                        }
                    });
                }
            ));
        }
    }

    loadPages(credentials: TypedFileCredentials, pages: number[]) {
        return this.http.post(this.configService.getViewerApiEndpoint() + Api.LOAD_DOCUMENT_PAGE + "s", {
            'guid': credentials.guid,
            'fileType': credentials.fileType,
            'password': credentials.password,
            'pages': pages
        }, Api.httpOptionsJson);
    }
}
