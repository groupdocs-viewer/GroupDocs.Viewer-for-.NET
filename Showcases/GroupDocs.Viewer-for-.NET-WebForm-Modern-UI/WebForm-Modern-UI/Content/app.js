'use strict';

var ngApp = angular.module('GroupDocsViewer', ['ngMaterial', 'ngResource']);

ngApp.constant('FilePath', 'candy.pdf');

ngApp.factory('FilesFactory', function ($resource) {
    return $resource('/files', {}, {
        query: {
            method: 'GET',
            isArray: true
        }
    });
});

ngApp.factory('DocumentPagesFactory', function ($resource) {
    return $resource('/documentinfo?file=:filename', {}, {
        query: {
            method: 'GET',
            isArray: false
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
    function ThumbnailsController($rootScope, $scope, $sce, $mdSidenav, DocumentPagesFactory, FilePath) {

        $scope.isLeftSidenavVislble = false;
        if (FilePath) {
            $scope.selectedFile = FilePath;
            $scope.docInfo = DocumentPagesFactory.query({
                filename: FilePath
            });

        }

        $scope.$on('selected-file-changed', function (event, selectedFile) {
            $scope.selectedFile = selectedFile;
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
                return $sce.trustAsResourceUrl('/PageImage?width=300&file=' + selectedFile + '&page=' + itemNumber);
            }
        };
        $scope.createAttachmentThumbnailPageUrl = function (selectedFile, attachment, itemNumber) {
            if ($scope.isLeftSidenavVislble) {
                return $sce.trustAsResourceUrl('/AttachmentImage?width=300&file=' + selectedFile + '&attachment=' + attachment + '&page=' + itemNumber);
            }
        };

    }
);

ngApp.controller('PagesController',
    function ThumbnailsController($scope, $sce, $document, DocumentPagesFactory, FilePath) {
        if (FilePath) {
            $scope.selectedFile = FilePath;
            $scope.docInfo = DocumentPagesFactory.query({
                filename: FilePath
            });

        }
        $scope.$on('selected-file-changed', function (event, selectedFile) {
            $scope.selectedFile = selectedFile;
            $scope.docInfo = DocumentPagesFactory.query({
                filename: selectedFile
            });
        });

        $scope.createPageUrl = function (selectedFile, itemNumber) {
            return $sce.trustAsResourceUrl('PageHtml?file=' + selectedFile + '&page=' + itemNumber);
        };
        $scope.createAttachmentPageUrl = function (selectedFile, attachmentName, itemNumber) {
            return $sce.trustAsResourceUrl('AttachmentHtml?file=' + selectedFile + '&attachment=' + attachmentName + '&page=' + itemNumber);
        };
        $scope.onLoad = function () {
        };
    }
);

ngApp.controller('AvailableFilesController', function AvailableFilesController($rootScope, $scope, FilesFactory, DocumentPagesFactory, FilePath) {
    if (FilePath) {
        $scope.selectedFile = FilePath;
        $scope.docInfo = DocumentPagesFactory.query({
            filename: FilePath
        });
    }
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
