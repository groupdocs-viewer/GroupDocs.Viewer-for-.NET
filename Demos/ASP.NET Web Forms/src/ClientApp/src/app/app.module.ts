import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { APP_BASE_HREF } from '@angular/common';

import { AppComponent } from './app.component';
import { ConfigService } from '@groupdocs.examples.angular/common-components';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ViewerConfigService, ViewerModule } from '@groupdocs.examples.angular/viewer';
import { BehaviorSubject, Observable } from 'rxjs';

import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { ViewerTranslateLoader } from "@groupdocs.examples.angular/viewer";

declare global {
  interface Window {
    apiEndpoint: string;
    uiSettingsPath: string;
  }
}

/*
export class StaticViewerConfigService {
    public updatedConfig: Observable<any> = new BehaviorSubject({
        pageSelector: true,
        download: true,
        upload: true,
        print: true,
        browse: true,
        rewrite: true,
        enableRightClick: true,
        filesDirectory: "",
        fontsDirectory: "",
        defaultDocument: "",
        watermarkText: "",
        preloadPageCount: 3,
        zoom: true,
        search: true,
        thumbnails: true,
        rotate: false,
        htmlMode: true,
        cache: true,
        saveRotateState: false,
        printAllowed: true,
        showGridLines: true,
        showLanguageMenu: true,
        defaultLanguage: 'en',
        supportedLanguages: ['en', 'fr', 'de']
    }).asObservable();

    load(): Promise<void> {
        return Promise.resolve();
    }
}
*/

export function configServiceFactory() {
  let config = new ConfigService();
  config.apiEndpoint = window.apiEndpoint;
  config.getViewerApiEndpoint = () => window.apiEndpoint;
  config.getConfigEndpoint = () => window.uiSettingsPath;
  return config;
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    ViewerModule,
    FontAwesomeModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useClass: ViewerTranslateLoader
      }
    })
  ],
  providers: [
    { provide: APP_BASE_HREF, useValue: '/' },
    { provide: ConfigService, useFactory: configServiceFactory },
/*
    { provide: ViewerConfigService, useClass: StaticViewerConfigService },
*/
    { provide: 'WINDOW', useValue: window },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
