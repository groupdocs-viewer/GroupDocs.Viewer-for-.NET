(function () {
	'use strict';
	var app = angular.module('myApp', [
		'ngSanitize',
		'ngAnimate',
		'ngQuantum',
		'ngResource'
	]);

	app.value('PageList', customPageList);

	app.run(['$templateCache', '$cacheFactory',
		function ($templateCache, $cacheFactory) {
			$templateCache = false;
		}]);

	app.config(['$httpProvider',
		function ($httpProvider) {
			$httpProvider.defaults.cache = false;
		}]);

	app.config(['$rootScopeProvider',
		function ($rootScopeProvider) {
			$rootScopeProvider.digestTtl(5);
		}]);

	app.factory('DocumentPagesFactory', function ($resource) {
		return $resource(apiURL + '/api/GroupDocsViewer/DocumentPages?file=' + fileName + '&folderName=' + folderName + '&userEmail=none&pageCount=0&lstPages=null', {}, {
			query: {
				method: 'GET',
				isArray: false
			}
		});
	});

	app.directive('infinityscroll', function () {
		return {
			restrict: 'A',
			link: function (scope, element, attrs) {
				element.bind('scroll', function () {
					if ((element[0].scrollTop + element[0].offsetHeight) >= element[0].scrollHeight) {
						//scroll reach to end
						scope.$apply(attrs.infinityscroll);
					}
				});
			}
		}
	});

	app.directive('myEnter', function () {
		return function ($scope, element, attrs) {
			element.bind("keydown keypress", function (event) {
				if (event.which === 13) {
					$scope.$apply(function () {
						$scope.$eval(attrs.myEnter);
					});
					event.preventDefault();
				}
			});
		};
	});

	app.factory('myService', function ($http) {
		var getData = function (page) {
			return $http({ method: "GET", url: apiURL + '/api/GroupDocsViewer/DocumentPages?file=' + fileName + '&folderName=' + folderName + '&userEmail=none&currentPage=' + page }).then(function (result) {
				return result;
			}, function (error) {
				alert(error.data.Message);
			});
		};

		return { getData: getData };
	});

	function GetPageData($scope, myService, page) {
		if (page <= totalPages) {
			console.log('page: ' + page);
			var myDataPromise = myService.getData(page);
			//console.log('GetPageData() executed for PageNumber: ' + page);
			//UpdatePager();
			$scope.loading.show();
			myDataPromise.then(function (result) {
				if (page > 2)
					customPageList.push('C:/tempFop/Converted/' + folderName + '/page_' + page + '.png');
                    //customPageList.push(value);
				var i = 0;
				angular.forEach(result.data, function (value) {
					if (i === 0 && result.data.length > 1) {
						totalPages = parseInt(value);
						UpdatePager();
						i++;
					}
					else {
						if (value.indexOf(':') >= 0) {
							//if (!customPageList.indexOf(value) >= 0 && page < 3)
                            if (!customPageList.indexOf(value) >= 0)
                                //customPageList.push('C:/tempFop/Converted/' + folderName + '/page_' + page + '.png');
                                customPageList.push(value);
							//console.log('value: ' + value); //customPageList.push('C:/tempFop/Converted/3fcf002a-8bf8-4ab2-8f27-b9ddc4b12579/page_' + page + '.png');

							if (customPageList.length > 0 && currentPageCount === 1) {
								document.getElementsByName("dvPages")[0].style.cssText = "height: 100vh; padding-top: 55px!important; width: auto!important; overflow: auto!important; background-color: #777; background-image: none!important;";
								$scope.navigatePage('+');
							}
						}
					}
					$scope.loading.hide();
				});
			});
		}
	}

	app.controller('ViewerAPIController',
		function ViewerAPIController($scope, $sce, $http, $window, DocumentPagesFactory, myService, $loading, $timeout, $q, $alert) {
			var $that = this;

			$scope.loadingButtonSucces = function () {
				return $timeout(function () {
					return true;
				}, 2000)
			}
			$scope.existApp = function () {
				if (featureName === '')
					window.location = '/viewer/total';
				else
					window.location = '/viewer/' + featureName;
			}
			$scope.loading = new $loading({
				busyText: ' Please wait while page loading...',
				theme: 'info',
				timeout: false,
				showSpinner: true
			});


			$scope.getError = function () {
				var deferred = $q.defer();

				setTimeout(function () {
					deferred.reject('Error');
				}, 1000);
				return deferred.promise;
			};

			$scope.displayAlert = function (title, message, theme) {
				$alert(message, title, theme);
			};

			if (customPageList.length <= 0) {
				$scope.PageList = customPageList;
			}

			GetPageData($scope, myService, currentPageCount);

			$scope.NextPage = function () {
				if (currentPageCount > totalPages) {
					currentPageCount = totalPages;
					return;
				}
				if (currentPageCount <= totalPages) {
					currentPageCount += 1;
					currentSelectedPage = currentPageCount;
					if ($scope.PageList.length < currentPageCount) {
						GetPageData($scope, myService, currentPageCount);
						//currentPageCount += 1;
						//if (currentPageCount <= totalPages) {
						//	GetPageData($scope, myService, currentPageCount);
						//}
						currentSelectedPage = currentPageCount - 1;
					}
					//UpdatePager();
				}
			};

			$scope.selected = false;
			$scope.slectedPageImage = function (event, PageData) {
				var domId = event.target.id.replace('img-page-', '').replace('imgt-page-', '');
				currentSelectedPage = parseInt(event.target.id.replace('img-page-', '').replace('imgt-page-', ''));

				UpdatePager();

				if (event.target.id.startsWith('imgt-page-')) {
					location.hash = 'page-view-' + domId;
					$scope.selected = PageData;
				}
			}

			$scope.navigatePage = function (options) {
				if (options === '+') {
					currentPageCount += 1;
					if (currentPageCount > totalPages) {
						currentPageCount = totalPages;
					}
				}
				else if (options === '-') {
					currentPageCount -= 1;

					if (currentPageCount < 1) {
						currentPageCount = 1;
					}
				}
				else if (options === 'f') {
					currentPageCount = 1;
				}
				else if (options === 'e') {
					currentPageCount = totalPages;
				}
				else {
					if (document.getElementById('inputcurrentpage').value !== '')
						currentPageCount = parseInt(document.getElementById('inputcurrentpage').value);

					if (currentPageCount > totalPages) {
						currentPageCount = totalPages;
					}

					if (currentPageCount < 1) {
						currentPageCount = 1;
					}
				}

				currentSelectedPage = currentPageCount;
				if ($scope.PageList.length < currentSelectedPage) {
					GetPageData($scope, myService, currentPageCount);
					$scope.$broadcast('UpdatePages');
					$scope.$broadcast('UpdateThumbnails');
					//GetPageData($scope, myService, currentPageCount + 1);
					//$scope.$broadcast('UpdatePages');
					//$scope.$broadcast('UpdateThumbnails');
				}
				UpdatePager();
				location.hash = 'page-view-' + currentSelectedPage;
			};

			$scope.createPageImage = function (selectedFile, indx) {
				if (indx <= (imagedata.length - 1)) {
					return imagedata[indx];
				}
				else {
					prevoiusIndx = indx;
					var imgData = $sce.trustAsResourceUrl(apiURL + '/api/GroupDocsViewer/pageimage?imagePath=' + selectedFile);
					imagedata.push(imgData);
					return imagedata[indx];
				}
			}

			$scope.PageWidth = PageWidth;
			$scope.itemSelected = 'h';
			$scope.zoomPage = function (zoomOption) {
				if (zoomOption === 'w') {
					ZoomValue = 1
					$scope.itemSelected = zoomOption
					ZoomPages(parseFloat(ZoomValue.toString()));
				}
				else if (zoomOption === 'h') {
					ZoomValue = 0.65
					$scope.itemSelected = zoomOption
					ZoomPages(ZoomValue);
				}
				else {
					if (ZoomValue === 0.65)
						ZoomValue = 0.50;
					ZoomPages(zoomOption);
					$scope.itemSelected = ZoomValue;
				}
				//console.log('$scope.PageWidth = PageWidth;: ' + $scope.PageWidth);
				$scope.PageWidth = PageWidth;
				//console.log('ZoomValue selected in dll: ' + ZoomValue);
			}

			$scope.printPdf = function () {
				var documentUrl = apiURL + '/api/GroupDocsViewer/PrintableHtml?file=' + fileName + '&folderName=' + folderName;

				$http({
					method: 'GET',
					url: documentUrl
				}).then(function (success) {
					var printWindow = $window.open('', '_blank', '', '');
					if (printWindow) {
						printWindow.document.open();
						printWindow.document.write(success.data);
						printWindow.document.close();
						printWindow.print();
						printWindow.close();
					}
				}, function (error) {
					console.log('error: ' + error);
				});
			};
		}
	);
})();