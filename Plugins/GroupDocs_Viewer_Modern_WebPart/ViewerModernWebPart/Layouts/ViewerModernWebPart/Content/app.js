'use strict';

var ngApp = angular.module('GroupDocsViewer', ['ngMaterial', 'ngResource']);

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

ngApp.controller('ToolbarController', function ToolbarController($rootScope, $scope, $mdSidenav) {
    $scope.toggleLeft = function () {
        $mdSidenav('left').toggle().then(function () {
            $rootScope.$broadcast('md-sidenav-toggle-complete', $mdSidenav('left'));
        });
    };

    $scope.$on('selected-file-changed', function ($event, selectedFile) {
        $scope.selectedFile = selectedFile;
    });
});

ngApp.controller('ThumbnailsController',
    function ThumbnailsController($rootScope, $scope, $sce, $mdSidenav, DocumentPagesFactory) {

        $scope.isLeftSidenavVislble = false;

        $scope.$on('selected-file-changed', function (event, selectedFile) {
            $scope.selectedFile = selectedFile;
            $scope.pages = DocumentPagesFactory.query({
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

        $scope.createThumbnailUrl = function (selectedFile, itemNumber) {
            if ($scope.isLeftSidenavVislble) {
                return $sce.trustAsResourceUrl('GetDocumentImage.aspx?width=300&file=' + selectedFile + '&page=' + itemNumber);
            }
        };

    }
);

ngApp.controller('PagesController',
    function ThumbnailsController($scope, $sce, $document, DocumentPagesFactory) {
        $scope.$on('selected-file-changed', function (event, selectedFile) {
            $scope.selectedFile = selectedFile;
            $scope.pages = DocumentPagesFactory.query({
                filename: JSON.stringify(selectedFile)
            });
        });

        $scope.createPageUrl = function (selectedFile, itemNumber) {
            return $sce.trustAsResourceUrl('GetDocumentHtml.aspx?file=' + selectedFile + '&page=' + itemNumber);
        };

        $scope.onLoad = function () {
        };
    }
);

ngApp.controller('AvailableFilesController', function AvailableFilesController($rootScope, $scope, FilesFactory) {
    $scope.onOpen = function () {
        $scope.list = FilesFactory.query();
    };

    $scope.onChange = function ($event) {
        $rootScope.$broadcast('selected-file-changed', $scope.selectedFile);
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
