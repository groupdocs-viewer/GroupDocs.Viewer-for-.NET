'use strict';

var ngApp = angular.module('GroupDocsViewer', ['ngMaterial', 'ngResource']);
ngApp.value('FilePath', DefaultFilePath);
ngApp.value('isImage', isImageToggle);
ngApp.value('Rotate', RotateAngel);
ZoomValue = (ZoomValue > 10 ? ZoomValue / 100 : ZoomValue);
ZoomValue = (ZoomValue <= 0 ? 0.05 : ZoomValue);
ngApp.value('Zoom', ZoomValue);
ngApp.value('Watermark', {
    Text: (ShowWatermark ? WatermarkText : ""),
    Color: WatermarkColor,
    Position: WatermarkPosition,
    Width: WatermarkWidth,
    Opacity: WatermarkOpacity
});

ngApp.value('ShowHideTools', {
    IsShowWatermark: !ShowWatermark,
    IsShowImageToggle: !ShowImageToggle,
    IsZoomIn: !ShowZoomIn,
    IsZoomOut: !ShowZoomOut,
    IsRotateImage: !ShowRotateImage,
    IsPreviousDocument: !ShowPreviousDocument,
    IsNextDocument: !ShowNextDocument,
    IsDownload: !ShowDownload,
    IsPDFDownload: !ShowPDFDownload,
    IsFileSelection: !ShowFileSelection,
    IsThubmnailPanel: !ShowThubmnailPanel
});

ngApp.factory('FilesFactory', function ($resource) {
    return $resource('/files', {}, {
        query: {
            method: 'GET',
            isArray: true
        }
    });
});

ngApp.factory('DocumentPagesFactory', function ($resource) {
    return $resource('/document/info?file=:filename', {}, {
        query: {
            method: 'GET',
            isArray: false
        }
    });
});

ngApp.controller('ToolbarController', function ToolbarController($rootScope, $scope, $mdSidenav, isImage, Zoom, Watermark, ShowHideTools, FilePath) {
    $scope.toggleLeft = function () {
        $mdSidenav('left').toggle().then(function () {
            $rootScope.$broadcast('md-sidenav-toggle-complete', $mdSidenav('left'));
        });
    };
    $scope.openMenu = function ($mdOpenMenu, ev) {
        $mdOpenMenu(ev);
    };
    $scope.Watermark = {
        Text: Watermark.Text,
        Color: Watermark.Color,
        Position: Watermark.Position,
        Width: Watermark.Width,
        Opacity: Watermark.Opacity
    };
    $scope.Zoom = Zoom;
    $scope.ShowHideTools = {
        IsShowWatermark: ShowHideTools.IsShowWatermark,
        IsShowImageToggle: ShowHideTools.IsShowImageToggle,
        IsZoomIn: ShowHideTools.IsZoomIn,
        IsZoomOut: ShowHideTools.IsZoomOut,
        IsRotateImage: ShowHideTools.IsRotateImage,
        IsPreviousDocument: ShowHideTools.IsPreviousDocument,
        IsNextDocument: ShowHideTools.IsNextDocument,
        IsDownload: ShowHideTools.IsDownload,
        IsPDFDownload: ShowHideTools.IsPDFDownload,
        IsFileSelection: ShowHideTools.IsFileSelection,
        IsThubmnailPanel: ShowHideTools.IsThubmnailPanel
    };
    $scope.isImage = isImage;
    $scope.$on('selected-file-changed', function ($event, selectedFile) {
        $rootScope.selectedFile = selectedFile;
    });

    $scope.rotateDocument = function () {
        $rootScope.$broadcast('rotate-file', $rootScope.selectedFile);
    };

    $scope.selected = false;
    $scope.zoomInDocument = function () {
        ZoomValue = (ZoomValue > 10 ? ZoomValue / 100 : ZoomValue);
        ZoomValue = (ZoomValue <= 0 ? 0.05 : ZoomValue);
        ZoomValue += 0.25;
        Zoom = ZoomValue;
        if ($scope.isImage)
            $rootScope.$broadcast('zin-file', $rootScope.selectedFile);
        else
            resizeIFrame();

    };
    $scope.zoomOutDocument = function () {
        ZoomValue = (ZoomValue > 10 ? ZoomValue / 100 : ZoomValue);
        ZoomValue = (ZoomValue <= 0 ? 0.05 : ZoomValue);
        ZoomValue -= 0.25;
        Zoom = ZoomValue;
        if ($scope.isImage)
            $rootScope.$broadcast('zout-file', $rootScope.selectedFile);
        else
            resizeIFrame();
    };
    $scope.zoomLevels = function (selectedzoomlevel) {
        console.log(selectedzoomlevel);
        ZoomValue = parseFloat(selectedzoomlevel);
        Zoom = ZoomValue;
        if ($scope.isImage)
            $rootScope.$broadcast('zin-file', $rootScope.selectedFile);
        else
            resizeIFrame();
    }
    $scope.togelToImageDocument = function () {
        $rootScope.$broadcast('toggle-file', $rootScope.selectedFile);
        isImageToggle = !$scope.isImage;
        resizeIFrame();
        $scope.isImage = !$scope.isImage;
    };
    $scope.nextDocument = function () {
        if ($rootScope.list.indexOf($rootScope.selectedFile) + 1 == $rootScope.list.length) {
            $rootScope.$broadcast('selected-file-changed', $rootScope.list[0]);
        }
        else {
            $rootScope.$broadcast('selected-file-changed', $rootScope.list[$rootScope.list.indexOf($rootScope.selectedFile) + 1]);
        }
    };

    $scope.previousDocument = function () {
        if ($rootScope.list.indexOf($rootScope.selectedFile) - 1 == -1) {
            $rootScope.$broadcast('selected-file-changed', $rootScope.list[$rootScope.list.length - 1]);
        }
        else {
            $rootScope.$broadcast('selected-file-changed', $rootScope.list[$rootScope.list.indexOf($rootScope.selectedFile) - 1]);
        }
    };
});

ngApp.controller('ThumbnailsController',
    function ThumbnailsController($rootScope, $scope, $sce, $mdSidenav, DocumentPagesFactory, FilePath, Watermark, ShowHideTools, Rotate) {
        $scope.isLeftSidenavVislble = false;
        if (FilePath) {
            $rootScope.selectedFile = FilePath;
            $scope.docInfo = DocumentPagesFactory.query({
                filename: FilePath
            });

        }
        $scope.$on('selected-file-changed', function (event, selectedFile) {
            $rootScope.selectedFile = selectedFile;
            $scope.docInfo = DocumentPagesFactory.query({
                filename: selectedFile
            });

        });
        $scope.$on('md-sidenav-toggle-complete', function ($event, component) {
            $scope.isLeftSidenavVislble = component.isOpen();
        });


        $scope.onThumbnailClick = function ($event, item) {
            $mdSidenav('left').toggle().then(function () {
                location.hash = 'page-view-' + item.number;
                $rootScope.$broadcast('md-sidenav-toggle-complete', $mdSidenav('left'));
                $scope.selected = item;
            });
        };
        $scope.onAttachmentThumbnailClick = function ($event, name, number) {
            $mdSidenav('left').toggle().then(function () {
                location.hash = 'page-view-' + name + '-' + number;
                $rootScope.$broadcast('md-sidenav-toggle-complete', $mdSidenav('left'));
            });
        };
        $scope.createThumbnailUrl = function (selectedFile, itemNumber) {
            if ($scope.isLeftSidenavVislble) {
                return $sce.trustAsResourceUrl('/page/image?width=300&file=' + selectedFile
                    + '&page=' + itemNumber
                    + '&watermarkText=' + Watermark.Text
                    + '&watermarkColor=' + Watermark.Color
                    + '&watermarkPosition=' + Watermark.Position
                    + '&watermarkWidth=' + Watermark.Width
                    + '&watermarkOpacity=' + Watermark.Opacity
                    + '&rotate=' + Rotate);
            }
        };
        $scope.createAttachmentThumbnailPageUrl = function (selectedFile, attachment, itemNumber) {
            if ($scope.isLeftSidenavVislble) {
                return $sce.trustAsResourceUrl('/attachment/image?width=300&file=' + selectedFile
                    + '&attachment=' + attachment
                    + '&page=' + itemNumber
                    + '&watermarkText=' + Watermark.Text
                    + '&watermarkColor=' + Watermark.Color
                    + '&watermarkPosition=' + Watermark.Position
                    + '&watermarkWidth=' + Watermark.Width
                    + '&watermarkOpacity=' + Watermark.Opacity);
            }
        };

    }
);

ngApp.controller('PagesController',
    function ThumbnailsController($rootScope, $scope, $sce, $document, DocumentPagesFactory, FilePath, Watermark, ShowHideTools, isImage, Rotate, Zoom) {
        if (FilePath) {
            $rootScope.selectedFile = FilePath;
            $scope.docInfo = DocumentPagesFactory.query({
                filename: FilePath
            });
            //isImage = $scope.isImage;

        }

        $scope.$on('selected-file-changed', function (event, selectedFile) {
            $rootScope.selectedFile = selectedFile;
            $scope.docInfo = DocumentPagesFactory.query({
                filename: selectedFile
            });
        });
        $scope.$on('rotate-file', function (event, selectedFile) {
            $rootScope.selectedFile = selectedFile;
            if (Rotate <= 270)
                Rotate += 90;
            else
                Rotate = 0;
        });
        $scope.$on('zin-file', function (event, selectedFile) {
            $rootScope.selectedFile = selectedFile;
            Zoom = ZoomValue;
        });
        $scope.$on('zout-file', function (event, selectedFile) {
            $rootScope.selectedFile = selectedFile;
            Zoom = ZoomValue;
        });
        $scope.$on('toggle-file', function (event, selectedFile) {
            $rootScope.selectedFile = selectedFile;
            isImage = !isImage;
        });
        $scope.createPageUrl = function (selectedFile, itemNumber) {
            if (isImage) {
                return $sce.trustAsResourceUrl('/page/image?file='
                        + selectedFile + '&width=700&page=' + itemNumber
                        + '&watermarkText=' + Watermark.Text
                        + '&watermarkColor=' + Watermark.Color
                        + '&watermarkPosition=' + Watermark.Position
                        + '&watermarkWidth=' + Watermark.Width
                        + '&watermarkOpacity=' + Watermark.Opacity
                        + '&rotate=' + Rotate
                        + '&zoom=' + parseInt(Zoom * 100));
            }
            else {
                return $sce.trustAsResourceUrl('/page/html?file='
                        + selectedFile + '&page=' + itemNumber
                        + '&watermarkText=' + Watermark.Text
                        + '&watermarkColor=' + Watermark.Color
                        + '&watermarkPosition=' + Watermark.Position
                        + '&watermarkWidth=' + Watermark.Width
                        + '&watermarkOpacity=' + Watermark.Opacity);
            }
        };
        $scope.createAttachmentPageUrl = function (selectedFile, attachmentName, itemNumber) {
            return $sce.trustAsResourceUrl('/attachment/html?file=' + selectedFile
                    + '&attachment=' + attachmentName
                    + '&page=' + itemNumber
                    + '&watermarkText=' + Watermark.Text
                    + '&watermarkColor=' + Watermark.Color
                    + '&watermarkPosition=' + Watermark.Position
                    + '&watermarkWidth=' + Watermark.Width
                    + '&watermarkOpacity=' + Watermark.Opacity);
        };
    }
);

ngApp.directive('iframeSetDimensionsOnload', [function () {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            element.on('load', function () {
                var body = element[0].contentWindow.document.body,
                            html = element[0].contentWindow.document.documentElement,
                            height = Math.max(
                                body.scrollHeight,
                                body.offsetHeight,
                                html.clientHeight,
                                html.scrollHeight,
                                html.offsetHeight
                            );

                element.css('width', '100%');
                element.css('height', parseInt(height) + 'px');
                if ($scope.isImage) {
                    element[0].contentWindow.document.body.style = "text-align: center !important;";
                }
                //resizeIFrame();
            });
        }
    }
}]);

ngApp.directive('cardSetDimensions', function ($window) {
    return{
        link: function($scope, element, attrs){
            //element.css('height', $window.innerHeight*ZoomValue + 'px');
            element.css('width', '100%');
            var height = element.innerHeight;
            height = parseInt(height) + 10;
            height = (height * (parseFloat(ZoomValue) < 1 ? 1 : parseFloat(ZoomValue)));
            height = parseInt(height);
            element.css('height', parseInt(height) + 'px');
            console.log(height);
            if ($scope.isImage) {
                //element.contentWindow.document.body.style = "text-align: center !important;";
            }
            //resizeIFrame();
        }
    }
});

ngApp.controller('AvailableFilesController', function AvailableFilesController($rootScope, $scope, FilesFactory, DocumentPagesFactory, FilePath) {
    $rootScope.list = FilesFactory.query();
    if (FilePath) {
        $rootScope.list = [FilePath];
        $rootScope.selectedFile = $rootScope.list[0];
        $rootScope.$broadcast('selected-file-changed', $rootScope.selectedFile);
        $scope.docInfo = DocumentPagesFactory.query({
            filename: FilePath
        });
    }

    $scope.onOpen = function () {
        $rootScope.list = FilesFactory.query();

    };
    $scope.onChange = function (item) {
        $rootScope.$broadcast('selected-file-changed', item);
    };

});

//setInterval(function () {
//    var list = document.getElementsByTagName('iframe');
//    for (var i = 0; i < list.length; i++) {
//        var iframe = list[i],
//            body = iframe.contentWindow.document.body,
//            html = iframe.contentWindow.document.documentElement,
//            height = Math.max(
//                body.scrollHeight,
//                body.offsetHeight,
//                html.clientHeight,
//                html.scrollHeight,
//                html.offsetHeight
//            );

//        iframe.style.height = height + 'px';
//    }
//}, 1572);
