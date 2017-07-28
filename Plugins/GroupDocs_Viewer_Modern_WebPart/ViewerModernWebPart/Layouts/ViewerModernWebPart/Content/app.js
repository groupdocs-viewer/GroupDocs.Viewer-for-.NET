'use strict';

var ngApp = angular.module('GroupDocsViewer', ['ngMaterial', 'ngResource']);

ngApp.constant('FilePath', '');

ngApp.constant('Watermark', {
    Text: "Watermark Text",
    Color: 16711680,
    Position: 'Diagonal',
    Width: null,
    Opacity: 255
});

ngApp.factory('FilesFactory', function ($resource) {
    return $resource('Home.aspx/files', {}, {
        query: {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' },
            data: ''
        }
    });
});

ngApp.factory('DocumentInfoFactory', function ($resource) {
    return $resource('/document/info?file=:filename', {}, {
        get: {
            method: 'GET'
        }
    });
});

ngApp.factory('DocumentPagesFactory', function ($resource) {
    return $resource('Home.aspx/GetDocumentPages?file=:filename', {}, {
        query: {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' },
            data: ''

        }
    });
});

ngApp.controller('ToolbarController', function ToolbarController($rootScope, $scope, $mdSidenav, Watermark,FilePath) {
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

    $scope.$on('selected-file-changed', function ($event, selectedFile) {
        $rootScope.selectedFile = selectedFile;
    });

    $scope.nextDocument = function () {
        if ($rootScope.list.d.indexOf($rootScope.selectedFile) + 1 == $rootScope.list.d.length) {
            $rootScope.$broadcast('selected-file-changed', $rootScope.list.d[0]);
        }
        else {
            $rootScope.$broadcast('selected-file-changed', $rootScope.list.d[$rootScope.list.d.indexOf($rootScope.selectedFile) + 1]);
        }
    };
    $scope.previousDocument = function () {
        if ($rootScope.list.d.indexOf($rootScope.selectedFile) - 1 == -1) {
            $rootScope.$broadcast('selected-file-changed', $rootScope.list.d[$rootScope.list.length - 1]);
        }
        else {
            $rootScope.$broadcast('selected-file-changed', $rootScope.list.d[$rootScope.list.d.indexOf($rootScope.selectedFile) - 1]);
        }
    };
});

ngApp.controller('ThumbnailsController',
    function ThumbnailsController($rootScope, $scope, $sce, $mdSidenav, DocumentPagesFactory, FilePath, Watermark) {

        $scope.isLeftSidenavVislble = false;
        if (FilePath) {
            $rootScope.selectedFile = FilePath;
            $scope.docInfo = DocumentPagesFactory.query({
                filename: JSON.stringify(FilePath)
            });

        }

        $scope.$on('selected-file-changed', function (event, selectedFile) {
            $rootScope.selectedFile = selectedFile;
            $scope.docInfo = DocumentPagesFactory.query({
                filename: JSON.stringify(selectedFile)
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
                return $sce.trustAsResourceUrl('GetDocumentImage.aspx?width=300&file=' + selectedFile
                    + '&page=' + itemNumber
                    + '&watermarkText=' + Watermark.Text
                    + '&watermarkColor=' + Watermark.Color
                    + '&watermarkPosition=' + Watermark.Position
                    + '&watermarkWidth=' + Watermark.Width
                    + '&watermarkOpacity=' + Watermark.Opacity);
            }
        };
        $scope.createAttachmentThumbnailPageUrl = function (selectedFile, attachment, itemNumber) {
            if ($scope.isLeftSidenavVislble) {
                return $sce.trustAsResourceUrl('GetAttachmentImage.aspx?width=300&file=' + selectedFile
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
    function ThumbnailsController($rootScope, $scope, $sce, $document, DocumentPagesFactory, FilePath, Watermark) {
        if (FilePath) {
            $rootScope.selectedFile = FilePath;
            $scope.docInfo = DocumentPagesFactory.query({
                filename: JSON.stringify(FilePath)
            });
        }
        $scope.$on('selected-file-changed', function (event, selectedFile) {
          
            $rootScope.selectedFile = selectedFile;
            $scope.docInfo = DocumentPagesFactory.query({
                filename: JSON.stringify(selectedFile)
            });
        });

        $scope.createPageUrl = function (selectedFile, itemNumber) {
            return $sce.trustAsResourceUrl('GetDocumentHtml.aspx?file='
              + selectedFile + '&page=' + itemNumber
              + '&watermarkText=' + Watermark.Text
              + '&watermarkColor=' + Watermark.Color
              + '&watermarkPosition=' + Watermark.Position
              + '&watermarkWidth=' + Watermark.Width
              + '&watermarkOpacity=' + Watermark.Opacity);
        };
        $scope.createAttachmentPageUrl = function (selectedFile, attachmentName, itemNumber) {
            return $sce.trustAsResourceUrl('GetAttachmentHtml.aspx?file=' + selectedFile
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

ngApp.controller('AvailableFilesController', function AvailableFilesController($rootScope, $scope, FilesFactory, FilePath) {
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
