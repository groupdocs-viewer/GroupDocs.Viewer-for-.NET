'use strict';

var ngApp = angular.module('GroupDocsViewer', ['ngMaterial', 'ngResource']);

ngApp.constant('FilePath', '');
ngApp.constant('isImage', false);
ngApp.constant('Rotate', 0);
ngApp.constant('Zoom', 0);
ngApp.constant('Watermark', {
    Text: "Watermark Text",
    Color: 16711680,
    Position: 'Diagonal',
    Width: null,
    Opacity: 255
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

ngApp.controller('ToolbarController', function ToolbarController($rootScope, $scope, $mdSidenav, Watermark, FilePath) {
    $scope.toggleLeft = function () {
        $mdSidenav('left').toggle().then(function () {
            $rootScope.$broadcast('md-sidenav-toggle-complete', $mdSidenav('left'));
        });
    };
    $scope.watermark = {
        Text: Watermark.Text,
        Color: Watermark.Color,
        Position: Watermark.Position,
        Width: Watermark.Width,
        Opacity: Watermark.Opacity
    };
    $scope.isImage = false;
    $scope.$on('selected-file-changed', function ($event, selectedFile) {
        $rootScope.selectedFile = selectedFile;
    });

    $scope.rotateDocument = function () {
        $rootScope.$broadcast('rotate-file', $rootScope.selectedFile);
    };
    $scope.zoomInDocument = function () {
        $rootScope.$broadcast('zin-file', $rootScope.selectedFile);
    };
    $scope.zoomOutDocument = function () {
        $rootScope.$broadcast('zout-file', $rootScope.selectedFile);
    };
    $scope.togelToImageDocument = function () {
        $rootScope.$broadcast('toggle-file', $rootScope.selectedFile);
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
    function ThumbnailsController($rootScope, $scope, $sce, $mdSidenav, DocumentPagesFactory, FilePath, Watermark, Rotate) {
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
                    + '&rotate=90');
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
    function ThumbnailsController($rootScope, $scope, $sce, $document, DocumentPagesFactory, FilePath, Watermark, isImage,Rotate,Zoom) {
        if (FilePath) {
            $rootScope.selectedFile = FilePath;
            $scope.docInfo = DocumentPagesFactory.query({
                filename: FilePath
            });
            isImage = $scope.isImage;
            
        }
        
        $scope.$on('selected-file-changed', function (event, selectedFile) {
            $rootScope.selectedFile = selectedFile;
            $scope.docInfo = DocumentPagesFactory.query({
                filename: selectedFile
            });
        });
        $scope.$on('rotate-file', function (event, selectedFile) {
            $rootScope.selectedFile = selectedFile;
            Rotate = 90;
        });
        $scope.$on('zin-file', function (event, selectedFile) {
            $rootScope.selectedFile = selectedFile;
            Rotate = 0;
            Zoom += 20;
        });
        $scope.$on('zout-file', function (event, selectedFile) {
            $rootScope.selectedFile = selectedFile;
            Rotate = 0;
            Zoom -= 20;
        });
        $scope.$on('toggle-file', function (event, selectedFile) {
            $rootScope.selectedFile = selectedFile;
            Rotate = 0;
            isImage = !isImage;
        });
        $scope.createPageUrl = function (selectedFile, itemNumber) {
            if (isImage)
                return $sce.trustAsResourceUrl('/page/image?width=400&file='
                    + selectedFile + '&page=' + itemNumber
                    + '&watermarkText=' + Watermark.Text
                    + '&watermarkColor=' + Watermark.Color
                    + '&watermarkPosition=' + Watermark.Position
                    + '&watermarkWidth=' + Watermark.Width
                    + '&watermarkOpacity=' + Watermark.Opacity
                    + '&rotate=' + Rotate
                    + '&zoom=' + Zoom);
            return $sce.trustAsResourceUrl('/page/html?file='
                    + selectedFile + '&page=' + itemNumber
                    + '&watermarkText=' + Watermark.Text
                    + '&watermarkColor=' + Watermark.Color
                    + '&watermarkPosition=' + Watermark.Position
                    + '&watermarkWidth=' + Watermark.Width
                    + '&watermarkOpacity=' + Watermark.Opacity);
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
        $scope.onLoad = function () {
        };
    }
);

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


setInterval(function () {
    var list = document.getElementsByTagName('iframe');
    for (var i = 0; i < list.length; i++) {
        var iframe = list[i],
            body = iframe.contentWindow.document.body,
            html = iframe.contentWindow.document.documentElement,
            height = Math.max(
                body.scrollHeight,
                body.offsetHeight,
                html.clientHeight,
                html.scrollHeight,
                html.offsetHeight
            );

        iframe.style.height = height + 'px';
    }
}, 1572);
