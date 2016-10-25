(function ($) {
    $.widget("ui.groupdocsViewer", {
        _viewModel: null,
        options: {
            enableViewerInit: true,
            supportTextSelection: true,
            resourcePrefix: ""
        },

        _create: function () {
            this._viewer = this.element.find('.doc_viewer').groupdocsViewer(
            $.extend(this.options, {
                element: this.element,
                applicationPath: $.ui.groupdocsViewer.prototype.applicationPath,
                widgetInstance: this
            })
            );
            this._viewModel = this.getViewModel();
            this.initControlsAndHandlers();
        },


        getViewModel: function () {
            if (this._viewModel == null) {
                this._viewModel = this._createViewModel();
            }
            return this._viewModel;
        },

        _createViewModel: function () {
            var vm = new window.groupdocs.groupdocsViewerViewModel(this.options);
            return vm;
        },

        on: function (eventName, handler) {
            this.element.on(eventName, handler);
        },

        off: function (eventName, handler) {
            this.element.off(eventName, handler);
        },

        setWidth: function (width) {
            this._viewModel.setWidth(width);
        },

        setHeight: function (height) {
            this._viewModel.setHeight(height);
        },

        openNextPage: function () {
            this._viewModel.openNextPage();
        },

        openPreviousPage: function () {
            this._viewModel.openPreviousPage();
        },

        setPage: function (pageNumber) {
            this._viewModel.setPage(pageNumber);
        },

        openFirstPage: function () {
            this._viewModel.openFirstPage();
        },

        openLastPage: function () {
            this._viewModel.openLastPage();
        },

        showFileBrowser: function () {
            this._viewModel.showFileBrowser();
        },

        setViewerMode: function (mode) {
            this._viewModel.setViewerMode(mode);
        },

        zoomIn: function () {
            this._viewModel.zoomIn();
        },

        zoomOut: function () {
            this._viewModel.zoomOut();
        },

        setZoom: function (zoomValue) {
            this._viewModel.setZoom(zoomValue);
        },

        downloadDocument: function () {
            this._viewModel.downloadDocument();
        },

        printDocument: function () {
            this._viewModel.printDocument();
        },

        searchForward: function (text, isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact) {
            this._viewModel.searchForward(text, isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact);
        },

        searchBackward: function (text, isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact) {
            this._viewModel.searchBackward(text, isCaseSensitive, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact);
        },

        clearSearchValue: function () {
            this._viewModel.clearSearchValue();
        },

        getDocumentPageCount: function () {
            return this._viewModel.getDocumentPageCount();
        },

        loadDocument: function (documentPath) {
            this._viewModel.loadDocument(documentPath);
        },

        initControlsAndHandlers: function () {
            this.initializErrorModal(this.element, this._viewer, this._viewModel);
        },
        initializErrorModal:  function (annotationWidget, annotationsViewer, annotationsViewerVM) {

            // initialize error modal dialog
            window.jerror = function (msg, handler, title) {
                $(annotationWidget).trigger("error.groupdocs", msg);

                if (annotationsViewerVM.enableStandardErrorHandling) {
                    var ttl = title || 'Error';

                    if (!msg) msg = 'Sorry, we\'re unable to perform your request right now. Please try again later.';

                    $('#jerrormodal h3').text(ttl);
                    $('#jerrormodalText').text(msg.Reason ? msg.Reason : msg);

                    if (handler) {
                        $('#jerrormodal').one('hidden', handler);
                    }

                    $('#jerrormodal').modal('show');
                }
            }


            if ($('#jerrormodal').length > 0)
                return;

            $("<div class='grpdx jerrorwrapper'> <div id='jerrormodal' class='modal fade modal2' style='z-index: 9999'>" +
                "  <div class='modal_inner_wrapper'>" +
                "      <a class='popclose' data-dismiss='modal'></a>" +
                "      <div class='modal_header'>" +
                "          <h3>Error</h3>" +
                "      </div>" +
                "      <div class='modal_content'>" +
                "          <div class='modal_input_wrap_left'>" +
                "              <p id='jerrormodalText' class='modaltext left'>An unexpected error occured. Please contact Support team for the assistance.</p>" +
                "          </div>" +
                "      </div>" +
                "  </div>" +
                "</div></div>").appendTo('body');

            $('#jerrormodal').modal({ show: false });

        },

        rotateCurrentPage: function (rotationAmount) {
            this._viewModel._rotatePage(rotationAmount);
        },

        setLoadingState: function (set) {
            this._viewModel.setLoadingState(set);
        },

        getContentControlDescriptions: function () {
            return this._viewModel.getContentControlDescriptions();
        },

        navigateToContentControl: function (number) {
            this._viewModel.navigateToContentControl(number);
        },

        destroy: function () {
            this._viewModel.destroy();
        }

    });

    if (!window.groupdocs)
        window.groupdocs = {};

    window.groupdocs.groupdocsViewerViewModel = function (options) {
        $.extend(this, options);
        this._create(options);
    };

    $.extend(window.groupdocs.groupdocsViewerViewModel.prototype, {
        groupdocsViewerWrapper: null,
        browserIsInternetExplorer: false,
        browserIsChrome: false,
        resizeTimeoutId: null,
        viewModes: { ScrollMode: 1, BookMode: 2 },
        viewMode: null,
        licElement: null,
        printImageElements: null,

        _create: function (options) {
            this._model = new groupdocsViewerModel(options);
            this._init(options);
        },

        _init: function (options) {
            var groupdocsViewerWrapper;
            var container = this.element;
            this.viewerId = window.groupdocs.viewerId;
            var settings = $.extend(
                { hostUrl: this.applicationPath, handlerUrlSuffix: this._model._portalService._urlSuffix, docViewerId: "docViewer" + this.viewerId }, options);
            this.printImageElements = new Array();
            window.groupdocs.viewerId++;
            var browserIsIE9OrLess = false;
            if (options.enableViewerInit) {
                var style;
                var browserIsIE8 = false;
                if ($.browser.msie) {
                    this.browserIsInternetExplorer = true;
                    if ($.browser.version == 8 || $.browser.version == 9) {
                        browserIsIE9OrLess = true;
                        if ($.browser.version == 8)
                            browserIsIE8 = true;
                    }

                    style = ".grpdx input[type='text']::-ms-clear {display: none;}"; // disable X for clearing search text
                    $("<style>" + style + "</style>").appendTo("head");
                }

                var browserIsChrome;
                var isChromium = window.chrome;
                var vendorName = window.navigator.vendor;
                var isOpera = window.navigator.userAgent.indexOf("OPR") > -1;
                if (!!isChromium && vendorName === "Google Inc." && isOpera == false)
                    browserIsChrome = true;
                this.browserIsChrome = browserIsChrome;

                var classWithNumber = "grpdx" + settings.docViewerId;
                var self = this;
                var browserDependentCssClass = "";
                if (self.browserIsInternetExplorer && settings.useHtmlBasedEngine) {
                    browserDependentCssClass = " ie";
                    if (browserIsIE8) {
                        browserDependentCssClass += " ie8";
                    }
                }

                var headerStyle = "";
                if (!settings.showHeader) {
                    headerStyle = "style=\"display: none\"";
                }

                container.each(function () {
                    $(
                    '<div dir="ltr" class="col-lg-12 col-md-10 col-sm-10 col-xs-10 groupdocs_viewer_wrapper grpdx ' + classWithNumber + /*browserDependentCssClass + */'">' +
                        '<div class="col-lg-12 col-md-10 col-sm-10 col-xs-10 viewer_header header_sidescroll" ' + headerStyle + '>' +
                        '   <div class="col-lg-12 col-md-10 col-sm-10 col-xs-10 viewer_header_wrapper">' +
                        '      <a class="btnOpen new_head_tools_btn h_t_i_browser" data-tooltip="Open File" data-localize-tooltip="OpenFile"></a>' +
                        '          <a class="new_head_tools_btn h_t_i_nav2 previous_document" data-tooltip="Previous Document" data-localize-tooltip="Previous Document"></a>' +
                        '          <a class="new_head_tools_btn h_t_i_nav3 next_document" data-tooltip="Next Document" data-localize-tooltip="Next Document"></a>' +


                        '      <div name="printAndDownloadToolbar" class="new_head_tools_wrapper left">' +
                        '          <a class="new_head_tools_btn h_t_i_download btn_download" data-tooltip="Download" data-localize-tooltip="Download"></a>' +
                        '          <a class="new_head_tools_btn h_t_i_print print_button" data-tooltip="Print" data-localize-tooltip="Print"></a>' +

                        '      </div>' +
                        '      <div class="navigation-bar' + (browserIsIE8 ? " ie8" : "") + '">' +
                        '      </div>' +
                        '      <div class="new_head_tools_wrapper zoom_wrappper">' +
                        '      </div>' +
                        '      <div class="new_head_tools_dropdown_wrapper viewTypeMenu">' +
                        '			<a class="new_head_tools_btn head_tool_dropdown_btn h_t_i_singlepage" data-bind="click: toggleDropDownMenu" href="#" data-tooltip="View Mode" data-localize-tooltip="ViewMode"></a>' +
                        '			<ul class="dropdown-menu head_tool_dropdown" style="display: none;" data-bind="style: {display: (dropDownMenuIsVisible() ? \'block\' : \'none\')}">' +
                        '				<li style="display: inline">' +
                        '					<a data-bind="click: openScrollView" href="#">' +
                        '						<span class="h_t_d_i_scroll"></span>' +
                        '						<p data-localize="ScrollView">Scroll View</p>' +
                        '					</a>' +
                        '				</li>' +
                        '				<li style="display: inline" name="openDoublePageFlipViewMenuItem">' +
                        '					<a data-bind="click: openDoublePageFlipView" href="#">' +
                        '						<span class="h_t_d_i_double"></span>' +
                        '						<p data-localize="BookMode">Double Page Flip</p>' +
                        '					</a>' +
                        '				</li>' +

                        '				<li style="display: inline">' +
                        '					<a data-bind="click: openOnePageInRowView" href="#">' +
                        '						<span class="h_t_d_i_scroll"></span>' +
                        '						<p data-localize="OnePageInRow">One Page in Row</p>' +
                        '					</a>' +
                        '				</li>' +

                        '				<li style="display: inline">' +
                        '					<a data-bind="click: openTwoPagesInRowView" href="#">' +
                        '						<span class="h_t_d_i_double"></span>' +
                        '						<p data-localize="TwoPagesInRow">Two Pages in Row</p>' +
                        '					</a>' +
                        '				</li>' +

                        '				<li style="display: inline">' +
                        '					<a data-bind="click: openCoverThenTwoPagesInRowView" href="#">' +
                        '						<span class="h_t_d_i_double"></span>' +
                        '						<p data-localize="CoverThenTwoPagesInRow">Cover then Two Pages in Row</p>' +
                        '					</a>' +
                        '				</li>' +


                        '			</ul>' +
                        '		</div>' +

                        '      <div name="search_wrapper" class="new_head_tools_wrapper" data-bind="visible:visible">' +
                        '      </div>' +

                        (settings.supportPageRotation ?
                        '<div class="new_head_tools_wrapper">' +
                        '      <a name="rotateClockwise" class="h_t_i_rotatecl new_head_tools_btn" data-tooltip="Rotate Clockwise" data-localize-tooltip="RotateClockwise"></a>' +
                        '      <a name="rotateCounterClockwise" class="h_t_i_rotatecon new_head_tools_btn" data-tooltip="Rotate Counter-Clockwise" data-localize-tooltip="RotateCounterClockwise"></a>' +
                        '</div>'
                        : "") +
                        '   </div>' +
                        '</div>' +
                        '<div class="fileOpenDialogWrapper" style="display: none"></div>' +
                        '<div class="viewer_mainwrapper ' + browserDependentCssClass + '">' +
                        '   <div id=' + settings.docViewerId + ' class="doc_viewer" data-bind="event: { scroll: function(item, e) { this.ScrollDocView(item, e); }, scrollstop: function(item, e) { this.ScrollDocViewEnd(item, e);e.returnValue = false;return true; } }">' +
                        '   </div>' +
                        '   <div class="doc_viewer_wrapper_page_flip" style="overflow: auto; top: -50000px; position: absolute;height: 100%">' +
                        '   </div>' +
                        (settings.showThumbnails ? '   <a class="thumbs_btn" href="#"></a>' : '') +
                        '</div>' +
                    //'<a class="thumbs_btn" href="#"></a>' +
                        '<div name="jGDerror" class="modal_dialog_wrapper jerrorwrapper">' +
                        '   <div class="modal_dialog_overlay">' +
                        '       &nbsp;' +
                        '   </div>' +
                        '   <div class="modal_dialog_content_wrapper">' +
                        '       <div class="modal_dialog_header">' +
                        '          Error' +
                        '       </div>' +
                        '       <div class="modal_dialog_download_link">Download file</div>' +
                        '       <div class="modal_dialog_content">' +
                        '       </div>' +
                        '   </div>' +
                        '</div>' +

                        '<div name="messageDialog" class="modal_dialog_content_wrapper modal_progressbar" style="display:none">' +
                        '   <a name="minimizeButton" class="icon_minimize" href="#">&ndash;</a>' +
                        '   <a name="maximizeButton" class="icon_maximize" href="#">+</a>' +
                        '   <div class="modal_dialog_header">' +
                        '      <span name="alwaysVisibleTitle">Printing </span>' +
                        '      <span name="visibleWhenMinimizedTitle" class="percent">0%</span>' +
                        '   </div>' +
                        '   <div class="modal_dialog_content">' +
                        '      <p data-localize="PreparingPages" name="message">Preparing the pages</p>' +
                        '      <div class="progressbar">' +
                        '      <div style="width: 50%" class="progress"></div></div>' +
                        '   </div>' +
                        '</div>' +

                        '<div name="messageDialogPdf" class="modal_dialog_content_wrapper modal_progressbar" style="display:none">' +
                        '   <a name="minimizeButtonPdf" class="icon_minimize" href="#">&ndash;</a>' +
                        '   <a name="maximizeButtonPdf" class="icon_maximize" href="#">+</a>' +
                        '   <div class="modal_dialog_header">' +
                        '      <span name="alwaysVisibleTitlePdf">Printing </span>' +
                        '   </div>' +
                        '   <div class="col-lg-12 col-md-10 col-sm-10 col-xs-10 modal_dialog_content">' +
                        '      <p data-localize="PreparingPages" name="messagePdf">Preparing the pages</p>' +
                        '   </div>' +
                        '</div>' +

                    '</div>'
                    ).appendTo($(this));
                });
            }
            $.fn.attachDragger = function () {
                var attachment = false, lastPosition, position, difference;
                $($(this).selector).on("mousedown mouseup mousemove", function (e) {
                    if (e.type == "mousedown") attachment = true, lastPosition = [e.clientX, e.clientY];
                    if (e.type == "mouseup") attachment = false;
                    if (e.type == "mousemove" && attachment == true) {
                        position = [e.clientX, e.clientY];
                        difference = [(position[0] - lastPosition[0]), (position[1] - lastPosition[1])];
                        $(this).scrollLeft($(this).scrollLeft() - difference[0]);
                        $(this).scrollTop($(this).scrollTop() - difference[1]);
                        lastPosition = [e.clientX, e.clientY];
                    }
                });
                $(window).on("mouseup", function () {
                    attachment = false;
                });
            }
            $("#"+settings.docViewerId+"").attachDragger();
            this.groupdocsViewerWrapper = groupdocsViewerWrapper = container.find(".groupdocs_viewer_wrapper");
            var viewerHeader = this.viewerHeader = groupdocsViewerWrapper.find(".viewer_header");
            var viewerMainWrapper = this.viewerMainWrapper = groupdocsViewerWrapper.find(".viewer_mainwrapper");

            if (!settings.showHeader) {
                viewerHeader.height(0);
                viewerMainWrapper.css("top", "0");
            }

            if (!options.enableViewerInit)
                return;

            if (settings.filePath == "") {
                settings.openThumbnails = false; // close thumbnails when no file is set
            }

            var docViewerSelector = "#" + settings.docViewerId;
            var docViewerJquery = $(docViewerSelector);
            var searchWrapper = groupdocsViewerWrapper.find("[name='search_wrapper']");

            if (settings.useHtmlBasedEngine) {
                viewerHeader.find("li[name='openDoublePageFlipViewMenuItem']").hide();

                if (!settings.supportTextSelection) {
                    style = "." + classWithNumber + " .html_pages_container{" +
                        "-webkit-touch-callout: none;" +
                        "-webkit-user-select: none;" +
                        "-khtml-user-select: none;" +
                        "-moz-user-select: none;" +
                        "-ms-user-select: none;" +
                        "user-select: none;" +
                        "}";
                    $("<style>" + style + "</style>").appendTo("head");
                    if (this.browserIsInternetExplorer) {
                        docViewerJquery.on("selectstart", function (e) {
                            e.preventDefault();
                            return true;
                        });
                    }
                }

                //settings.supportPageReordering = false;
            }

            var viewerWidth, viewerHeight;

            if (settings.width)
                viewerWidth = settings.width;
            else
                viewerWidth = container.width();
            //groupdocsViewerWrapper.width(viewerWidth);

            if (settings.height)
                viewerHeight = settings.height;
            else
                viewerHeight = container.height();
            groupdocsViewerWrapper.height(viewerHeight);

            var selectionContent = null;
            if (!settings.useHtmlBasedEngine) {
                selectionContent = groupdocsViewerWrapper.find("[name='selection-content']");
                if (selectionContent.length == 0)
                    selectionContent = $("<textarea readonly='readonly' rows='1' cols='1' name='selection-content'></textarea>'").appendTo(groupdocsViewerWrapper);
            }

            var jerror = groupdocsViewerWrapper.find("[name='jGDerror']");

            jerror.find(".modal_dialog_overlay").click(function () {
                jerror.hide();
            });
            var navigationWrapper = groupdocsViewerWrapper.find(".navigation-bar");
            var zoomingWrapper = groupdocsViewerWrapper.find('.zoom_wrappper');
            var viewerBookModeWrapper = groupdocsViewerWrapper.find(".doc_viewer_wrapper_page_flip");
            var fileOpenDialogWrapper = this.fileOpenDialogWrapper = groupdocsViewerWrapper.find(".fileOpenDialogWrapper");

            if (!settings.supportTextSelection) {
                var disableSelectionRectCss = docViewerSelector + " .ui-selectable-helper {display: none;visibility: hidden}";
                $("<style>" + disableSelectionRectCss + "</style>").appendTo("head");
            }

            var thumbnailImageWidth;
            if (settings.thumbnailsContainerWidth) {
                var regularContainerWidth = 203;
                var regularThumbnailImageWidth = 150;
                var regularThumbnailListItemWidth = 187;

                var scrollbarWidth = this.getScrollbarWidth();
                var thumbnailContainerWidth = Math.round(settings.thumbnailsContainerWidth);
                var widthRatio = (regularContainerWidth - scrollbarWidth) / (thumbnailContainerWidth - scrollbarWidth);
                thumbnailImageWidth = Math.round(regularThumbnailImageWidth / widthRatio);
                var thumbnailListItemWidth = Math.round(regularThumbnailListItemWidth / widthRatio);
                style = "div.thumbnailsContainer{width:" + thumbnailContainerWidth + "px}";
                style += "div.thumbnailsContainer ul li img{width:" + thumbnailImageWidth + "px}";
                style += "div.thumbnailsContainer ul li{min-width:" + thumbnailListItemWidth + "px}";
                style += ".thumbs_btn_slide{left:" + (thumbnailContainerWidth + 2) + "px}";

                $("<style>" + style + "</style>").appendTo("head");
            }

            style = "";
            if (settings.searchHighlightColor) {
                style += "." + classWithNumber + " .search_highlight_html, ." + classWithNumber + " .search-highlight " +
                        "{background-color:" + settings.searchHighlightColor +
                        "; fill:" + settings.searchHighlightColor +
                        "}";
            }

            if (settings.currentSearchHighlightColor) {
                //style += "#" + settings.docViewerId + " .current_search_highlight {background-color:" + settings.currentSearchHighlightColor + " !important}";
                style += ".grpdx." + classWithNumber + " .current_search_highlight {" +
                         "background-color:" + settings.currentSearchHighlightColor +
                         "; fill:" + settings.currentSearchHighlightColor +
                         "}";
            }

            //if (settings.showOnePageInRow || settings.viewerStyle == window.groupdocs.OnePageInRow) {
            //    style += ".grpdx." + classWithNumber + " .doc-page {display:block; margin-left:auto; margin-right:auto;}";
            //}

            if (settings.useEmScaling) {
                style += ".grpdx." + classWithNumber + " .html_page_contents {transform-origin:initial}";
            }

            if (style)
                $("<style>" + style + "</style>").appendTo("head");


            //var viewerHeaderHeight = viewerHeader.outerHeight(true);
            //viewerMainWrapper.css("top", viewerHeaderHeight.toString() + "px");

            function localizeElements() {
                self._localizeElements();
            }

            docViewerJquery.bind("onHtmlCreated", localizeElements);
            navigationWrapper.bind("onHtmlCreated", localizeElements);
            zoomingWrapper.bind("onHtmlCreated", localizeElements);
            viewerBookModeWrapper.bind("onHtmlCreated", localizeElements);
            fileOpenDialogWrapper.bind("onHtmlCreated", localizeElements);

            var searchOptions = {
                createHtml: true,
                viewerElement: docViewerJquery,
                useCaseSensitiveSearch: settings.useCaseSensitiveSearch,
                searchForSeparateWords: settings.searchForSeparateWords,
                treatPhrasesInDoubleQuotesAsExactPhrases: settings.treatPhrasesInDoubleQuotesAsExactPhrases,
                useHtmlBasedEngine: settings.useHtmlBasedEngine,
                searchIsVisible: settings.showSearch,
                useRtl: settings.useRtl,
                useAccentInsensitiveSearch: settings.useAccentInsensitiveSearch,
                useVirtualScrolling: settings.useVirtualScrolling
            };

            var thumbnailQuality;
            if (settings.useHtmlBasedEngine)
                thumbnailQuality = 20;
            else
                thumbnailQuality = settings.quality;

            var thumbnailsOptions = {
                createHtml: true,
                thumbnailWidth: thumbnailImageWidth,
                quality: thumbnailQuality,
                useHtmlBasedEngine: settings.useHtmlBasedEngine,
                useHtmlThumbnails: settings.useHtmlThumbnails,
                useInnerThumbnails: settings.useInnerThumbnails,
                supportPageReordering: settings.supportPageReordering,
                use_pdf: settings.supportTextSelection ? "true" : "false",
                ignoreDocumentAbsence: settings.ignoreDocumentAbsence,
                supportPageRotation: settings.supportPageRotation,
                openThumbnails: settings.openThumbnails,
                instanceIdToken: settings.instanceIdToken,
                locale: settings.locale,
                _mode: "webComponent"
            };

            var thumbnails;
            if (settings.showThumbnails) {
                thumbnails = viewerMainWrapper;
            }
            else {
                thumbnails = null;
            }

            var viewerOptions = {
                watermarkText: settings.watermarkText,
                watermarkColor: settings.watermarkColor,
                watermarkPosition: settings.watermarkPosition,
                watermarkWidth: settings.watermarkWidth,
                watermarkOpacity: settings.watermarkOpacity,
                preventTouchEventsBubbling: settings.preventTouchEventsBubbling,
                searchForSeparateWords: settings.searchForSeparateWords,
                treatPhrasesInDoubleQuotesAsExact: settings.treatPhrasesInDoubleQuotesAsExact,
                usePngImagesForHtmlBasedEngine: settings.usePngImagesForHtmlBasedEngine,
                alwaysOnePageInRow: settings.showOnePageInRow || settings.viewerStyle == window.groupdocs.OnePageInRow,
                onlyShrinkLargePages: settings.onlyShrinkLargePages,
                loadAllPagesOnSearch: settings.loadAllPagesOnSearch,
                useEmScaling: settings.useEmScaling,
                convertWordDocumentsCompletely: settings.convertWordDocumentsCompletely,
                ignoreDocumentAbsence: settings.ignoreDocumentAbsence,
                usePdf: settings.supportTextSelection,
                preloadPagesOnBrowserSide: settings.preloadPagesOnBrowserSide,
                supportPageRotation: settings.supportPageRotation,
                useAccentInsensitiveSearch: settings.useAccentInsensitiveSearch,
                useRtl: settings.useRtl,
                viewerLayout: settings.viewerStyle,
                useVirtualScrolling: settings.useVirtualScrolling,
                supportListOfContentControls: settings.supportListOfContentControls,
                supportListOfBookmarks: settings.supportListOfBookmarks,
                embedImagesIntoHtmlForWordFiles: settings.embedImagesIntoHtmlForWordFiles,
                instanceIdToken: settings.instanceIdToken,
                browserIsIE9OrLess: browserIsIE9OrLess,
                locale: settings.locale,
                passwordForOpening: settings.passwordForOpening,
                saveFontsInAllFormats: settings.saveFontsInAllFormats,
                downloadButtonMode: settings.downloadButtonMode,
                allowDocumentDownloadingOnFailure: settings.allowDocumentDownloadingOnFailure,
                printWithWatermark: settings.printWithWatermark
            };

            var menuClickedEvent = "onMenuClicked";
            var viewTypeMenu = groupdocsViewerWrapper.find(".viewTypeMenu");
            var viewTypeViewModel = {
                dropDownMenuIsVisible: ko.observable(false),
                dropDownMenuClicked: false,
                openScrollView: function () {
                    self.setMultiplePagesInRowLayout();
                },
                openDoublePageFlipView: function () {
                    self.openDoublePageFlipView();
                },

                openOnePageInRowView: function () {
                    self.openOnePageInRowView();
                },
                openTwoPagesInRowView: function () {
                    self.openTwoPagesInRowView();
                },
                openCoverThenTwoPagesInRowView: function () {
                    self.openCoverThenTwoPagesInRowView();
                },

                showDropDownMenu: function (show) {
                    this.dropDownMenuIsVisible(show);
                },
                toggleDropDownMenu: function (viewModel, event) {
                    this.dropDownMenuIsVisible(!this.dropDownMenuIsVisible());
                    this.dropDownMenuClicked = true;
                    viewTypeMenu.trigger(menuClickedEvent);
                    event.stopPropagation();
                }
            };

            var viewerAdapter = this.viewerAdapter = new DocViewerAdapter(
                {
                    fileId: settings.filePath,
                    fileVersion: "0",
                    quality: settings.quality,
                    use_pdf: settings.supportTextSelection ? "true" : "false",
                    docSpace: docViewerJquery,
                    _mode: "webComponent",
                    createHtml: true,
                    initialZoom: settings.initialZoom,
                    viewerWidth: viewerWidth,
                    viewerHeight: viewerMainWrapper.height(),
                    //alwaysOnePageInRow: true,
                    docViewerId: settings.docViewerId,
                    zoomToFitWidth: settings.zoomToFitWidth,
                    zoomToFitHeight: settings.zoomToFitHeight,
                    printWithWatermark: settings.printWithWatermark,
                    navigation: navigationWrapper,
                    navigationOptions: { createHtml: true },
                    thumbnails: thumbnails,
                    thumbnailsOptions: thumbnailsOptions,
                    zooming: zoomingWrapper,
                    zoomingOptions: { createHtml: true },
                    //search: settings.showSearch ? searchWrapper : null,
                    search: searchWrapper,
                    searchOptions: searchOptions,
                    preloadPagesCount: settings.preloadPagesCount,
                    docSpacePageFlip: settings.useHtmlBasedEngine || (settings.viewerStyle == this.viewModes.ScrollMode && !settings.showViewerStyleControl) ? null : viewerBookModeWrapper,
                    //layout: settings.viewerStyle,
                    usePageNumberInUrlHash: false,
                    selectionContent: selectionContent,
                    imageHorizontalMargin: 14,
                    imageVerticalMargin: 14,
                    useJavaScriptDocumentDescription: true,
                    searchPartialWords: true,
                    variableHeightPageSupport: true,
                    textSelectionSynchronousCalculation: false,
                    minimumImageWidth: settings.minimumImageWidth,
                    fileDisplayName: settings.fileDisplayName,
                    pageContentType: settings.useHtmlBasedEngine ? "html" : "image",
                    searchExactText: settings.searchExactText,
                    viewerOptions: viewerOptions,
                    viewTypeMenu: viewTypeMenu,
                    viewTypeViewModel: viewTypeViewModel,
                    instanceId: this.viewerId
                });

            if (settings.showFolderBrowser) {
                var fileOpenDialogOptions = {
                    hostUrl: settings.hostUrl,
                    userId: settings.userId,
                    userKey: settings.userKey,
                    fileExplorer: groupdocsViewerWrapper.find(".file_browser_content"),
                    fileUploader: groupdocsViewerWrapper.find(".file_browser_toolbar"),
                    resourcePrefix: settings.resourcePrefix,
                    urlHashEnabled: false,
                    instanceIdToken: settings.instanceIdToken
                };
                fileOpenDialogWrapper.fileOpenDialog(fileOpenDialogOptions);
                fileOpenDialogWrapper.find(".popclose").click(function () {
                    self._hideFileOpenDialog();
                });

            }
            localizeElements();

            var thumbsButton = container.find(".thumbs_btn");
            if (settings.useInnerThumbnails)
                thumbsButton.hide();

            function setThumbsImage() {
                if (settings.showThumbnails && settings.thumbsImageBase64Encoded != null) {
                    thumbsButton.css("background-image", "url(data:image/png;base64," + settings.thumbsImageBase64Encoded + ")")
                        .css("background-position", "0 0");
                }
            }

            setThumbsImage();

            thumbsButton.click(function () {
                $(this).toggleClass("thumbs_btn_slide");
                container.find(".thumbnailsContainer").toggle();
                if ($.browser.msie) {
                    thumbsButton.css("background-image", "");
                    setThumbsImage();
                }

                return false;
            });

            groupdocsViewerWrapper.find(".btnOpen").click(function () {
                self._showFileOpenDialog();
            });
            groupdocsViewerWrapper.find(".next_document").click(function (e) {
                viewerAdapter.docViewerViewModel.loadDocument(GetNextFileName(e.currentTarget.offsetParent.offsetParent.parentElement.firstChild.className));
            });
            groupdocsViewerWrapper.find(".previous_document").click(function (e) {
                viewerAdapter.docViewerViewModel.loadDocument(GetPrevioustFileName(e.currentTarget.offsetParent.offsetParent.parentElement.firstChild.className));
            });
            groupdocsViewerWrapper.find("[name=rotateClockwise]").click(function () {
                self._rotatePage(90);
            });

            groupdocsViewerWrapper.find("[name=rotateCounterClockwise]").click(function () {
                self._rotatePage(-90);
            });

            groupdocsViewerWrapper.find(".file_browser_content").bind('fileSelected', function (e, metadata) {
                self._hideFileOpenDialog();
                self.fileDisplayName = viewerAdapter.docViewerViewModel.fileDisplayName = "";
                viewerAdapter.docViewerViewModel.loadDocument(metadata.path);
            });

            if (settings.showThumbnails && settings.openThumbnails) {
                container.find(".thumbs_btn").addClass("thumbs_btn_slide");
                container.find(".thumbnailsContainer").css("display", "block");
            }

            ko.applyBindings(viewTypeViewModel, viewTypeMenu.get(0));

            $("html").click(function () {
                if (self.viewerAdapter.zoomViewModel) {
                    self.viewerAdapter.zoomViewModel.showDropDownMenu(false);
                }
                viewTypeViewModel.showDropDownMenu(false);
            });

            if (settings.backgroundColor) {
                container.find('.groupdocs_viewer_wrapper').css('background-color', settings.backgroundColor);
                viewerHeader.css('background-color', settings.backgroundColor);
                container.find('.new_head_input').css('background-color', settings.backgroundColor);
                container.find('.new_head_tools_wrapper').css('background-color', settings.backgroundColor)
                    .css("box-shadow", "none");
                container.find('.thumbs_btn').css('background-color', settings.backgroundColor);
            }

            container.find(".btnOpen").css('display', (settings.showFolderBrowser ? '' : 'none'));
            container.find(".navigation-bar").css('display', (settings.showPaging ? '' : 'none'));
            zoomingWrapper.css('display', (settings.showZoom ? '' : 'none'));
            container.find(".btn_download").css('display', (settings.showDownload ? '' : 'none'));
            container.find(".next_document").css('display', (settings.showDocumentNavigation ? '' : 'none'));
            container.find(".previous_document").css('display', (settings.showDocumentNavigation ? '' : 'none'));
            container.find(".print_button").css('display', (settings.showPrint ? '' : 'none'));
            container.find(".viewTypeMenu").css('display', (settings.showViewerStyleControl ? '' : 'none'));
            if (settings.showPrint === false && settings.showDownload === false)
                container.find("[name='printAndDownloadToolbar']").css('display', 'none');
            if (settings.showSearch === false)
                searchWrapper.css('display', 'none');

            function constructCss3(selector, css3Property, value) {
                var prefixes = ["-moz-", "-webkit-", ""];
                var result = selector + "{";
                for (var i = 0; i < prefixes.length; i++) {
                    result += prefixes[i] + css3Property + ":" + value + ";";
                }
                result += "}";
                return result;
            }

            var styleForSettings = "";
            if (settings.toolbarButtonsBoxShadowStyle) {
                var boxShadowProperty = "box-shadow";
                var dynamicPageCss = constructCss3(".grpdx .new_head_tools_btn", boxShadowProperty, settings.toolbarButtonsBoxShadowStyle);
                styleForSettings += dynamicPageCss;

                if (settings.toolbarButtonsBoxShadowHoverStyle) {
                    dynamicPageCss = constructCss3(".grpdx .new_head_tools_btn:hover", boxShadowProperty, settings.toolbarButtonsBoxShadowHoverStyle);
                    styleForSettings += dynamicPageCss;
                }
            }

            if (settings.thumbnailsContainerBackgroundColor) {
                styleForSettings += ".grpdx div.thumbnailsContainer{background-color:" + settings.thumbnailBackgroundColor + "}\r\n";
            }

            if (settings.toolbarBorderBottomColor) {
                styleForSettings += ".grpdx .viewer_header{border-bottom-color:" + settings.toolbarBorderBottomColor + "}\r\n";
            }

            if (settings.thumbnailsContainerBorderRightColor) {
                styleForSettings += ".grpdx div.thumbnailsContainer{border-right-color:" + settings.thumbnailsContainerBorderRightColor + "}\r\n";
            }

            if (settings.toolbarInputFieldBorderColor) {
                styleForSettings += ".grpdx .new_head_input{border-color:" + settings.toolbarInputFieldBorderColor + "}\r\n";
            }

            if (settings.toolbarButtonBorderColor) {
                styleForSettings += ".grpdx .new_head_tools_btn{border-color:" + settings.toolbarButtonBorderColor + "}\r\n";
            }

            if (settings.useInnerThumbnails) {
                styleForSettings += ".grpdx #" + settings.docViewerId + "{display: inline-block}\r\n";
            }

            $("<style>" + styleForSettings + "</style>").appendTo("head");
            docViewerJquery.bind('onDocumentLoadComplete', function (e, data) {
                self.documentLoadCompleteHandler(data, groupdocsViewerWrapper, viewerMainWrapper);
            });

            docViewerJquery.bind('onDocumentLoaded', function (e, data) {
                self.documentLoadedHandler(data, groupdocsViewerWrapper, viewerMainWrapper);
            });

            docViewerJquery.bind('isDocumentSinglePaged.groupdocs', function (e, data) {
                self.documentSinglePagedHandler(data, navigationWrapper);
            });

            if (settings.viewerStyle == this.viewModes.BookMode) {
                viewTypeViewModel.openDoublePageFlipView();
            }
            else {
                this.viewMode = this.viewModes.ScrollMode;
            }

            var jerrorElement = groupdocsViewerWrapper.find("[name='jGDerror']");
            var jerrorElementContent = jerrorElement.find(".modal_dialog_content");
            var jerrorElementContentWrapper = jerrorElement.find(".modal_dialog_content_wrapper");
            var messageHeaderElement = jerrorElement.find(".modal_dialog_header");
            var messageHeaderDownloadLink = jerrorElement.find(".modal_dialog_download_link");
            jerrorElement.removeClass("jerrorwrapper");

            var viewerMainwrapper = groupdocsViewerWrapper.find(".viewer_mainwrapper");
            var initialized = false;
            if (!window.jGDError)
                window.jGDError = new Array();
            window.jGDError[this.viewerId] = function (msg, filePath) {
                $(container).trigger("error.groupdocs", msg);
                if (settings.enableStandardErrorHandling) {
                    msg = msg.replace(/^[\r\n\s]+|[\r\n\s]+$/g, "");
                    if (!msg)
                        msg = "Sorry, we're unable to perform your request right now. Please try again later.";
                    jerrorElement.css("height", "auto");
                    messageHeaderElement.text("Error");
                    if (settings.allowDocumentDownloadingOnFailure) {
                        var downloadUrl = jGroupdocs.stringExtensions.trimEnd(settings.applicationPath, '/') + '/document-viewer/GetFile' +
                            (settings.handlerUrlSuffix || '') + '?path=' + filePath + '&getPdf=false';
                        messageHeaderDownloadLink.html('<a href="' + downloadUrl + '" target="_blank">Download original file "' + filePath + '"</a>');

                    } else {
                        messageHeaderDownloadLink.remove();
                    }

                    var dialogWidth, dialogHeight;
                    if (msg.substring(0, 1) == "<") {
                        //jerrorElement.html(msg);
                        jerrorElementContent.html(msg);
                        var windowWidth = viewerMainwrapper.width();
                        var windowHeight = viewerMainwrapper.height();
                        if (windowWidth < 100)
                            dialogWidth = windowWidth;
                        else
                            dialogWidth = windowWidth - 100;

                        if (windowHeight < 100)
                            dialogHeight = windowHeight;
                        else
                            dialogHeight = windowHeight - 100;

                    }
                    else {
                        jerrorElementContent.text(msg);
                    }

                    if (dialogWidth != undefined) {
                        jerrorElementContentWrapper.css("margin-left", -dialogWidth / 2);
                        jerrorElementContentWrapper.width(dialogWidth);
                    }
                    if (dialogHeight != undefined)
                        jerrorElementContentWrapper.height(dialogHeight);

                    jerrorElement.show();

                    jerrorElementContentWrapper.css("margin-left", -jerrorElementContentWrapper.width() / 2);
                    jerrorElementContentWrapper.css("margin-top", -jerrorElementContentWrapper.height() / 2);
                }
            };

            var dialogElement = this.groupdocsViewerWrapper.find("[name='messageDialog']");
            var minimizeButton = dialogElement.find("[name='minimizeButton']");
            var maximizeButton = dialogElement.find("[name='maximizeButton']");
            minimizeButton.click(function () {
                dialogElement.addClass("min");
            });
            maximizeButton.click(function () {
                dialogElement.removeClass("min");
            });

            var dialogElementPdf = this.groupdocsViewerWrapper.find("[name='messageDialogPdf']");
            var minimizeButtonPdf = dialogElementPdf.find("[name='minimizeButtonPdf']");
            var maximizeButtonPdf = dialogElementPdf.find("[name='maximizeButtonPdf']");
            minimizeButtonPdf.click(function () {
                dialogElementPdf.addClass("min");
            });
            maximizeButtonPdf.click(function () {
                dialogElementPdf.removeClass("min");
            });

            this.resizeHandler();
        },

        documentLoadedHandler: function (data, groupdocsViewerWrapper, viewerMainWrapper) {
            this.printFrameLoaded = false;
            var bodyElement = $("body");
            var printFrameName = "printFrame" + this.viewerId;
            var printFrame = bodyElement.children("div.groupdocsPrintFrame[name='" + printFrameName + "'],div.groupdocsPrintFrameDeactivated[name='" + printFrameName + "']");
            if (printFrame.length == 0) {
                //var frameWidth = 500, frameHeight = 500;
                //printFrame = $("<iframe name='groupdocsPrintFrame' src='about:blank' style='width:" + frameWidth +
                //               "px;height:" + frameHeight + "px'></iframe>");
                printFrame = $("<div class='groupdocsPrintFrameDeactivated'></div>");
                printFrame.attr("name", printFrameName);
                //printFrame.appendTo(this.groupdocsViewerWrapper);
                printFrame.appendTo(bodyElement);
            }
            else
                printFrame.empty();

            this.printImageElements.length = 0;
            var pageCount = data.page_count;

            if (!data.lic && pageCount > 3)
                pageCount = 3;

            var imgElement;
            for (var pageNum = 0; pageNum < pageCount; pageNum++) {
                imgElement = $("<img/>").appendTo(printFrame);
                this.printImageElements.push(imgElement);
            }

            if (!data.lic && groupdocsViewerWrapper.find(".licBanner").length == 0) {
                viewerMainWrapper.addClass("viewer_mainwrapper_trial");
                //viewerMainWrapper.css("top", "94px");

                this.licElement = $("<div/>");
                this.licElement.addClass("banner_trial");
                if (!this.showHeader)
                    this.licElement.css("top", "0");

                var unlicensedMessage = this._getLocalizedString("This viewer has been created using an unlicensed version of ", "UnlicensedViewer");
                this.licElement.html(unlicensedMessage + " <a href='http://groupdocs.com' target='_blank'>GroupDocs</a> Viewer for .NET ");
                this.licElement.appendTo(groupdocsViewerWrapper);

                if (!this.showHeader)
                    viewerMainWrapper.css("top", this.licElement.height() + "px");
                this.resizeHandler();
            }
        },

        documentLoadCompleteHandler: function (data, groupdocsViewerWrapper, viewerMainWrapper) {
            var self = this;
            if (this.showImageWidth) {
                alert("Image width: " + data.page_size.Width);
            }

            this.downloadUrl = data.url;
            this.pdfDownloadUrl = data.pdfDownloadUrl;
            this.pdfPrintUrl = data.pdfPrintUrl;
            this.documentPath = data.guid;
            var downloadButton = groupdocsViewerWrapper.find(".btn_download");
            var printButton = groupdocsViewerWrapper.find(".print_button");
            downloadButton.unbind();
            printButton.unbind();
            //var printFrame = this.groupdocsViewerWrapper.find("iframe[name=groupdocsPrintFrame]");
            //printFrame.remove();

            var onlyFireEventsInClickHandlerFlag;
            if (this.downloadButtonMode === 1) {
                onlyFireEventsInClickHandlerFlag = false;
            } else {
                var finalDownloadUrl;
                if (this.downloadPdfFile && (typeof this.pdfDownloadUrl !== "undefined")) {
                    finalDownloadUrl = this.pdfDownloadUrl;
                } else {
                    finalDownloadUrl = this.downloadUrl;
                }

                downloadButton.attr('href', finalDownloadUrl);
                var targetValue;
                switch (this.downloadButtonMode) {
                    case 2:
                        targetValue = '_self';
                        break;
                    case 3:
                        targetValue = '_blank';
                        break;
                    default:
                        targetValue = '_self';
                        break;
                }
                downloadButton.attr('target', targetValue);
                onlyFireEventsInClickHandlerFlag = true;
            }

            downloadButton.bind({
                click: function () {
                    self._downloadDocument(onlyFireEventsInClickHandlerFlag);
                    return onlyFireEventsInClickHandlerFlag;
                }
            });


            //var printFrameLoaded = false;
            printButton.bind({
                click: function () {
                    self._printDocument();
                    return false;
                }
            });
        },

        documentSinglePagedHandler: function (isDocumentSinglePaged, navigationWrapper) {
            if (this.showPaging) {
                if (isDocumentSinglePaged)
                    navigationWrapper.hide();
                else
                    navigationWrapper.show();
            }
        },

        _localizeElements: function () {
            var self = this;
            if (this.localizedStrings != null) {
                self.element.find("[data-localize],[data-localize-ph],[data-localize-tooltip]").each(function () {
                    var that = $(this);
                    var localizationKey = that.attr("data-localize");
                    var localizationTextValue;
                    if (localizationKey) {
                        localizationTextValue = self.localizedStrings[localizationKey];
                        that.text(localizationTextValue);
                    }
                    else {
                        localizationKey = that.attr("data-localize-ph");
                        if (localizationKey) {
                            localizationTextValue = self.localizedStrings[localizationKey];
                            that.attr("placeholder", localizationTextValue);
                        }
                        else {
                            localizationKey = that.attr("data-localize-tooltip");
                            if (localizationKey) {
                                localizationTextValue = self.localizedStrings[localizationKey];
                                that.attr("data-tooltip", localizationTextValue);
                            }
                        }
                    }
                });
            }
        },

        getScrollbarWidth: function () {
            var scrollbarWidth = null;

            // Create the measurement node
            var scrollDivJquery = $("<div/>").css("width", "100px").css("height", "100px")
                .css("overflow", "scroll").css("position", "absolute").css("top", "-9999px");
            var scrollDiv = scrollDivJquery[0];
            //scrollDiv.className = "scrollbar-measure";
            document.body.appendChild(scrollDiv);

            // Get the scrollbar width
            scrollbarWidth = scrollDiv.offsetWidth - scrollDiv.clientWidth;

            // Delete the DIV 
            document.body.removeChild(scrollDiv);
            return scrollbarWidth;
        },

        resizeHandler: function () {
            if (this.showHeader) {
                var viewerHeaderNewHeight = this.viewerHeader.outerHeight(true);

                //if (viewerHeaderNewHeight != this.viewerHeaderHeight) {
                var licElementHeight = 0;
                if (this.licElement) {
                    licElementHeight = this.licElement.height();
                }

                if (viewerHeaderNewHeight != this.viewerMainWrapper.position().top - licElementHeight) {
                    var newTop = viewerHeaderNewHeight;

                    if (this.licElement) {
                        this.licElement.css("top", newTop.toString() + "px");
                        newTop += licElementHeight;
                    }
                    this.viewerMainWrapper.css("top", newTop.toString() + "px");
                    //this.viewerHeaderHeight = viewerHeaderNewHeight;
                    if (this.viewMode == this.viewModes.BookMode)
                        this.viewerAdapter.docViewerPageFlipViewModel.reInitSelectable();
                    else {
                        this.viewerAdapter.docViewerViewModel.reInitSelectable();
                    }
                    //this.viewerAdapter.docViewerViewModel.reInitCanvasOffset();
                }
            }
            if (this.useInnerThumbnails) {
                var thumbnailPanelWidth = 0;
                var thumbnailsViewModel = this.viewerAdapter.thumbnailsViewModel;
                if (thumbnailsViewModel)
                    thumbnailPanelWidth = thumbnailsViewModel.getThumbnailsPanelWidth();
                if (this.viewMode == this.viewModes.BookMode)
                    this.viewerAdapter.docViewerPageFlipViewModel.resizeViewerElement(thumbnailPanelWidth);
                else
                    this.viewerAdapter.docViewerViewModel.resizeViewerElement(thumbnailPanelWidth);
            }
            else {
                this.viewerAdapter.docViewerViewModel.loadImagesForVisiblePages();
            }

            this._setFitWidthAndHeightValues();
        },

        resizeHandlerWithDelay: function () {
            //if (this.browserIsInternetExplorer) {
            if (this.resizeTimeoutId)
                clearTimeout(this.resizeTimeoutId);
            var self = this;
            this.resizeTimeoutId = window.setTimeout(function () {
                self.resizeHandler();
            }, 1000);
            //}
        },

        setWidth: function (width) {
            this.groupdocsViewerWrapper.width(width);
            //this.loadImagesForVisiblePages();
            //this.loadImagesForVisiblePagesIe();
            this.resizeHandler();
            this.resizeHandlerWithDelay();
        },

        setHeight: function (height) {
            this.groupdocsViewerWrapper.height(height);
            this.resizeHandler();
            this.resizeHandlerWithDelay();
        },

        _showFileOpenDialog: function () {
            var self = this;
            this.fileOpenDialogWrapper.addClass("in");
            this.fileOpenDialogWrapper.show();

            this.backdrop = $('<div class="modal-backdrop fade" />').appendTo(this.groupdocsViewerWrapper),
            this.backdrop.click(function () {
                self._hideFileOpenDialog();
            });
            this.backdrop.addClass("in");
        },

        _hideFileOpenDialog: function () {
            this.backdrop.removeClass("in");
            this.backdrop.remove();
            this.fileOpenDialogWrapper.hide();
        },

        _rotatePage: function (angle) {
            this.viewerAdapter.docViewerViewModel.rotatePage(angle);
        },

        openScrollView: function () {
            var viewerWrapper = this.groupdocsViewerWrapper.find(".doc_viewer");
            var viewerWrapper2 = this.groupdocsViewerWrapper.find(".doc_viewer_wrapper_page_flip");
            viewerWrapper2.css("position", "absolute");
            viewerWrapper2.css("height", "100%");
            viewerWrapper2.hide();
            viewerWrapper.show();
            this.viewerAdapter.docViewerViewModel.openCurrentPage();
            if (this.viewerAdapter.search) {
                this.viewerAdapter.searchViewModel.showControls();
            }
        },

        setMultiplePagesInRowLayout: function () {
            this.openScrollView();
            this.viewerAdapter.docViewerViewModel.setLayout(window.groupdocs.ScrollMode);
            this.viewerAdapter.docViewerViewModel.reInitSelectable();
            this._setFitWidthAndHeightValues();

            this.viewMode = this.viewModes.ScrollMode;
        },

        openDoublePageFlipView: function () {
            if (!this.useHtmlBasedEngine) {
                var viewerWrapper = this.groupdocsViewerWrapper.find(".doc_viewer");
                var viewerWrapper2 = this.groupdocsViewerWrapper.find(".doc_viewer_wrapper_page_flip");
                //viewerWrapper2.show();
                viewerWrapper2.css("display", "inline-block");
                this.viewerAdapter.docViewerViewModel.setLayout(window.groupdocs.BookMode);
                this.viewerAdapter.docViewerPageFlipViewModel.openCurrentPage();
                viewerWrapper2.css("height", "");
                viewerWrapper2.css("top", "");
                viewerWrapper2.css("position", "");
                viewerWrapper.hide();
                this.viewMode = this.viewModes.BookMode;
                this.resizeHandler();
                this.viewerAdapter.docViewerPageFlipViewModel.reInitSelectable();
                this._setFitWidthAndHeightValues(true);
                if (this.viewerAdapter.search) {
                    this.viewerAdapter.searchViewModel.hideControls();
                }
            }
        },

        openOnePageInRowView: function () {
            this.openScrollView();
            this.viewerAdapter.docViewerViewModel.setLayout(window.groupdocs.OnePageInRow);
            this.viewerAdapter.docViewerViewModel.reInitSelectable();
            if (!this.useHtmlBasedEngine) {
                this.viewerAdapter.docViewerViewModel.openCurrentPage();
            }
        },

        openTwoPagesInRowView: function () {
            this.openScrollView();
            this.viewerAdapter.docViewerViewModel.setLayout(window.groupdocs.TwoPagesInRow);
            this.viewerAdapter.docViewerViewModel.reInitSelectable();
            if (!this.useHtmlBasedEngine) {
                this.viewerAdapter.docViewerViewModel.openCurrentPage();
            }
        },

        openCoverThenTwoPagesInRowView: function () {
            this.openScrollView();
            this.viewerAdapter.docViewerViewModel.setLayout(window.groupdocs.CoverThenTwoPagesInRow);
            this.viewerAdapter.docViewerViewModel.reInitSelectable();
            if (!this.useHtmlBasedEngine) {
                this.viewerAdapter.docViewerViewModel.openCurrentPage();
            }
        },

        _downloadDocument: function (onlyFireEvents) {
            this.element.trigger("onGDViewerDownloadButtonClick");
            this.element.trigger("downloadButtonClick.groupdocs");
            if (onlyFireEvents) {
                return false;
            }
            var downloadUrl = this.downloadUrl;
            if (this.downloadPdfFile && (typeof this.pdfDownloadUrl !== "undefined")) {
                downloadUrl = this.pdfDownloadUrl;
            }

            if (this.showDownloadErrorsInPopup) {
                $.fileDownload(downloadUrl, {
                    //preparingMessageHtml: "Requesting server, please wait...",
                    //failMessageHtml: "There was a problem with your download, please try again."
                    failCallback: function (responseHtml, url) {
                        window.jGDError(responseHtml, this.filePath);
                    },
                    cookieName: self.jqueryFileDownloadCookieName,
                    containerElement: this.groupdocsViewerWrapper
                });
            }
            else {
                window.location.href = downloadUrl;
            }
            return false;
        },

        _printDocument: function () {
            var self = this;

            var message, title;
            if (this.usePdfPrinting) {
                message = this._getLocalizedString("Printing", "Printing");
                title = this._getLocalizedString("Printing", "Printing");
                this._showMessageDialogPdf(message, title);
                var printWindow = window.open(this.pdfPrintUrl);

                var closeMessageDialog = function () {
                    self._hideMessageDialogPdf();
                };

                if (this.browserIsChrome)
                    printWindow.onload = closeMessageDialog;
                else
                    window.setTimeout(closeMessageDialog, 1000);
            }
            else {
                var ua = navigator.userAgent.toLowerCase();
                var isAndroid = ua.indexOf("android") > -1; //&& ua.indexOf("mobile");
                if (isAndroid)
                    alert("You seem to use an Android device. Your browser does not support the JavaScript print function.");

                var fileDisplayName = "";
                if (this.fileDisplayName)
                    fileDisplayName = this.fileDisplayName;

                function printFromIframe() {
                    printFrame[0].contentWindow.focus();
                    printFrame[0].contentWindow.print();
                }
                var useHtmlContentBasedPrinting = this.useHtmlBasedEngine && !this.useImageBasedPrinting;
                var bodyElement = $("body");
                var printFrameName = "printFrame" + this.viewerId;
                var printFrame = bodyElement.children("div.groupdocsPrintFrame[name='" + printFrameName + "'],div.groupdocsPrintFrameDeactivated[name='" + printFrameName + "']");
                var otherPrintFrames = bodyElement.children("div.groupdocsPrintFrame,div.groupdocsPrintFrameDeactivated").not(printFrame);
                otherPrintFrames.removeClass("groupdocsPrintFrame");
                otherPrintFrames.addClass("groupdocsPrintFrameDeactivated");
                printFrame.removeClass("groupdocsPrintFrameDeactivated");
                printFrame.addClass("groupdocsPrintFrame");

                var watermarkText = null, watermarkColor = null;
                var watermarkPosition = this.watermarkPosition, watermarkWidth = null;
                if (this.printWithWatermark) {
                    watermarkText = this.watermarkText;
                    watermarkColor = this.watermarkColor;
                    watermarkWidth = this.watermarkWidth;
                    watermarkOpacity = this.watermarkOpacity;
                }

                if (printFrame.length == 0) {
                    printFrame = $("<div class='groupdocsPrintFrame'></div>");
                    printFrame.attr("name", printFrameName);
                    printFrame.appendTo(bodyElement);
                }

                if (this.printFrameLoaded) {
                    window.print();
                }
                else {
                    message = this._getLocalizedString("Getting a printable version of the document",
                                                           "GettingPrintableVersionOfDocument");
                    title = this._getLocalizedString("Printing", "Printing");

                    this._showMessageDialog(message, title, 0);
                    this._model.getPrintableHtml(this.documentPath, useHtmlContentBasedPrinting, fileDisplayName,
                        this.quality, this.supportTextSelection,
                        watermarkText, watermarkColor,
                        watermarkPosition, watermarkWidth, watermarkOpacity,
                        this.ignoreDocumentAbsence,
                        this.instanceIdToken,
                        function (responseData) {
                            self._hideMessageDialog();
                            var pageImageUrl;
                            var pageCount = responseData.length;
                            var prepMessage = self._getLocalizedString("Preparing the pages", "PreparingPages");
                            prepMessage += ": ";
                            var pagesLoaded = 0;
                            self._showMessageDialog(prepMessage + pagesLoaded + "/" + pageCount, title, 0);
                            var pageNum;
                            var numberOfPagesInScreenDocument = self.printImageElements.length;
                            for (pageNum = numberOfPagesInScreenDocument; pageNum < pageCount; pageNum++) {
                                var imageElementWithoutUrl;
                                imageElementWithoutUrl = $("<img/>").appendTo(printFrame);
                                self.printImageElements.push(imageElementWithoutUrl);
                            }

                            for (pageNum = 0; pageNum < self.printImageElements.length; pageNum++) {
                                var imageElement;

                                function pageImageLoadHandler() {
                                    pagesLoaded++;
                                    self._updateMessageDialog(prepMessage + pagesLoaded + "/" + pageCount, title, pagesLoaded / pageCount * 100.);
                                    if (pagesLoaded >= pageCount) {
                                        self._hideMessageDialog();
                                        window.print();
                                        self.printFrameLoaded = true;
                                    }
                                }

                                pageImageUrl = responseData[pageNum];
                                imageElement = self.printImageElements[pageNum];
                                imageElement.load(pageImageLoadHandler).attr("src", pageImageUrl); //.appendTo(printFrame);
                            }
                        },
                        function (error) {
                            self._hideMessageDialog();
                            //jGDError(error);
                        },
                        this.locale);
                }
            }
            return false;
        },

        _showMessageDialog: function (message, title, progress) {
            var dialogElement = this._updateMessageDialog(message, title, progress);
            dialogElement.show();
        },

        _updateMessageDialog: function (message, title, progress) {
            var dialogElement = this.groupdocsViewerWrapper.find("[name='messageDialog']");
            var messageElement = dialogElement.find(".modal_dialog_content p[name='message']");
            messageElement.text(message);

            var headerElement = dialogElement.find(".modal_dialog_header");
            var alwaysVisibleTitleElement = headerElement.find("span[name='alwaysVisibleTitle']");
            alwaysVisibleTitleElement.text(title);

            var progressBarElement = dialogElement.find(".progress");
            if (typeof progress != "undefined") {
                var progressString = Math.round(progress) + "%";
                progressBarElement.css("width", progressString);
                var visibleWhenMinimizedTitle = headerElement.find("span[name='visibleWhenMinimizedTitle']");
                visibleWhenMinimizedTitle.text(progressString);
            }
            return dialogElement;
        },

        _hideMessageDialog: function () {
            var dialogElement = this.groupdocsViewerWrapper.find("[name='messageDialog']");
            dialogElement.hide();
        },

        // Printing message without progress bar for UsePdfPrinting(true) option

        _showMessageDialogPdf: function (message, title) {
            var dialogElement = this._updateMessageDialogPdf(message, title);
            dialogElement.show();
        },

        _updateMessageDialogPdf: function (message, title) {
            var dialogElement = this.groupdocsViewerWrapper.find("[name='messageDialogPdf']");
            var messageElement = dialogElement.find(".modal_dialog_content p[name='message']");
            messageElement.text(message);

            var headerElement = dialogElement.find(".modal_dialog_header");
            var alwaysVisibleTitleElement = headerElement.find("span[name='alwaysVisibleTitlePdf']");
            alwaysVisibleTitleElement.text(title);

            return dialogElement;
        },

        _hideMessageDialogPdf: function () {
            var dialogElement = this.groupdocsViewerWrapper.find("[name='messageDialogPdf']");
            dialogElement.hide();
        },

        _getLocalizedString: function (defaultValue, localizationKey) {
            var result = defaultValue;
            if (this.localizedStrings) {
                var localizationTextValue = this.localizedStrings[localizationKey];
                if (localizationTextValue)
                    result = localizationTextValue;
            }
            return result;
        },

        _setFitWidthAndHeightValues: function (isDoublePageFlipMode) {
            if (this.viewerAdapter.zooming) {
                var containerWidth, containerHeight;
                var fitWidthZoom, fitHeightZoom;
                if (isDoublePageFlipMode) {
                    fitWidthZoom = this.viewerAdapter.docViewerPageFlipViewModel.getFitWidthZoom();
                    fitHeightZoom = this.viewerAdapter.docViewerPageFlipViewModel.getFitHeightZoom();
                }
                else {
                    containerWidth = this.groupdocsViewerWrapper.width();
                    this.viewerAdapter.docViewerViewModel.setContainerWidth(containerWidth);
                    containerHeight = this.viewerMainWrapper.height();
                    this.viewerAdapter.docViewerViewModel.setContainerHeight(containerHeight);
                    fitWidthZoom = this.viewerAdapter.docViewerViewModel.getFitWidthZoom();
                    fitHeightZoom = this.viewerAdapter.docViewerViewModel.getFitHeightZoom();
                }
                this.viewerAdapter.zoomViewModel.setFitWidthZoom(fitWidthZoom);
                this.viewerAdapter.zoomViewModel.setFitHeightZoom(fitHeightZoom);
            }
        },

        openNextPage: function () {
            this.viewerAdapter.navigationViewModel.down();
        },

        openPreviousPage: function () {
            this.viewerAdapter.navigationViewModel.up();
        },

        setPage: function (pageNumber) {
            this.viewerAdapter.navigationViewModel.selectPage(pageNumber);
        },

        openFirstPage: function () {
            this.viewerAdapter.navigationViewModel.openFirstPage();
        },

        openLastPage: function () {
            this.viewerAdapter.navigationViewModel.openLastPage();
        },

        showFileBrowser: function () {
            this._showFileOpenDialog();
        },

        setViewerMode: function (mode) {
            switch (mode) {
                case window.groupdocs.ScrollMode:
                    this.openScrollView();
                    break;

                case window.groupdocs.BookMode:
                    this.openDoublePageFlipView();
                    break;

                case window.groupdocs.OnePageInRow:
                    this.openOnePageInRowView();
                    break;

                case window.groupdocs.TwoPagesInRow:
                    this.openTwoPagesInRowView();
                    break;

                case window.groupdocs.CoverThenTwoPagesInRow:
                    this.openCoverThenTwoPagesInRowView();
                    break;
            }
        },

        zoomIn: function () {
            this.viewerAdapter.zoomViewModel.zoomIn();
        },

        zoomOut: function () {
            this.viewerAdapter.zoomViewModel.zoomOut();
        },

        setZoom: function (zoomValue) {
            var actualZoomValue = zoomValue;
            switch (zoomValue) {
                case window.groupdocs.FitWidth:
                    actualZoomValue = this.viewerAdapter.zoomViewModel.getFitWidthZoomValue();
                    break;
                case window.groupdocs.FitHeight:
                    actualZoomValue = this.viewerAdapter.zoomViewModel.getFitHeightZoomValue();
                    break;
                default:
                    break;
            }
            this.viewerAdapter.zoomViewModel.setZoom({ value: actualZoomValue });
        },

        downloadDocument: function () {
            this._downloadDocument();
        },

        printDocument: function () {
            this._printDocument();
        },

        searchForward: function (text, useCaseSensitiveSearch, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact) {
            if (this.viewerAdapter.searchViewModel.searchValue() != text)
                this.viewerAdapter.searchViewModel.searched = false;
            this.viewerAdapter.searchViewModel.searchValue(text);
            this.viewerAdapter.searchViewModel.findNext(useCaseSensitiveSearch, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact);
        },

        searchBackward: function (text, useCaseSensitiveSearch, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact) {
            if (this.viewerAdapter.searchViewModel.searchValue() != text)
                this.viewerAdapter.searchViewModel.searched = false;
            this.viewerAdapter.searchViewModel.searchValue(text);
            this.viewerAdapter.searchViewModel.findPrevious(useCaseSensitiveSearch, searchForSeparateWords, treatPhrasesInDoubleQuotesAsExact);
        },

        clearSearchValue: function () {
            this.viewerAdapter.searchViewModel.clearValue();
        },

        getDocumentPageCount: function () {
            return this.viewerAdapter.docViewerViewModel.pageCount();
        },

        loadDocument: function (documentPath) {
            this.viewerAdapter.docViewerViewModel.loadDocument(documentPath);
        },

        setLoadingState: function (set) {
            this.viewerAdapter.docViewerViewModel.setLoadingState(set);
        },

        getContentControlDescriptions: function () {
            return this.viewerAdapter.docViewerViewModel.getContentControlDescriptions();
        },

        navigateToContentControl: function (number) {
            this.viewerAdapter.docViewerViewModel.navigateToContentControl(number);
        },

        destroy: function () {
            var bookModePagesContainer = this.groupdocsViewerWrapper.find(".doc_viewer_wrapper_page_flip .pages_container_flip");
            if (bookModePagesContainer.length != 0 && bookModePagesContainer.turn("is"))
                bookModePagesContainer.turn("destroy");
            this.groupdocsViewerWrapper.remove();
            $.Widget.prototype.destroy.call(this.widgetInstance);
        }
    });

    // Doc Viewer Model
    var groupdocsViewerModel = function (options) {
        $.extend(this, options);
        this._init();
    };

    $.extend(groupdocsViewerModel.prototype, {
        _portalService: null,
        _init: function () {
            this._portalService = Container.Resolve("PortalService");
        },

        getPrintableHtml: function (documentPath, useHtmlBasedEngine, fileDisplayName,
                                    quality, supportTextSelection,
                                    watermarkText, watermarkColor,
                                    watermarkPosition, watermarkWidth, watermarkOpacity,
                                    ignoreDocumentAbsence,
                                    instanceIdToken,
                                    callback, errorCallback, locale) {

            this._portalService.getImageUrlsAsync(
                                              null, null, documentPath, /*width*/null, null, 0, /*imageCount*/null, quality, supportTextSelection, /*this.fileVersion*/null,
                                              watermarkText, watermarkColor, watermarkPosition, watermarkWidth, watermarkOpacity,
                                              ignoreDocumentAbsence,
                                              useHtmlBasedEngine, /*supportPageRotation*/false,
                function (response) {
                    callback.apply(this, [response.data.imageUrls]);
                },
                function (error) {
                    errorCallback.apply(this, [error]);
                },
                instanceIdToken,
                locale
            );
        }
    });

    //$.ui.groupdocsViewer.prototype.useHttpHandlers = false;
    //$.ui.groupdocsViewer.prototype.applicationPath = null;
    $.support.cors = true;

    if (!jQuery.browser) {
        jQuery.browser = {};
        (function () {
            jQuery.browser.msie = false;
            jQuery.browser.version = 0;
            if (navigator.appName == 'Microsoft Internet Explorer') { // IE <=10
                if (navigator.userAgent.match(/MSIE ([0-9]+)\./)) {
                    jQuery.browser.msie = true;
                    jQuery.browser.version = RegExp.$1;
                }
            }
            else if (navigator.appName == 'Netscape') { // IE11+
                var ua = navigator.userAgent;
                var re = new RegExp("Trident/.*rv:([0-9]{1,}[\.0-9]{0,})");
                if (re.exec(ua) != null) {
                    //rv = parseFloat(RegExp.$1);
                    jQuery.browser.msie = true;
                    jQuery.browser.version = RegExp.$1;
                }
            }
        })();
    }

    window.groupdocs.ScrollMode = 1;
    window.groupdocs.BookMode = 2;
    window.groupdocs.OnePageInRow = 3;
    window.groupdocs.TwoPagesInRow = 4;
    window.groupdocs.CoverThenTwoPagesInRow = 5;
    window.groupdocs.FitWidth = -1;
    window.groupdocs.FitHeight = -2;
    window.groupdocs.viewerId = 1;

})(jQuery);