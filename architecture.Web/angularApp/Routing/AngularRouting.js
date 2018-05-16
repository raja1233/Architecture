
/// <reference path="../controller/PersonController.js" />


angular.module("architectureApp")
                .config(function ($urlRouterProvider, $stateProvider, $locationProvider) {
                    $urlRouterProvider.otherwise('/');
                    $locationProvider.hashPrefix("");
                    //state base routing
                    $stateProvider
                         .state('Details', {
                             url: '/',
                             templateUrl: 'angularApp/Views/Details.html',
                             controller: 'PostCtrl'
                         })
                        .state('List', {
                            url: '/List',
                            templateUrl: 'angularApp/Views/List.html',
                            controller: 'PostCtrl'
                        })
                        //###### query string here tells that it is optional and actual id will come with url on evnet
                        .state('EditData', {
                            url: '/EditData/:id?',
                            templateUrl: 'angularApp/Views/EditData.html',
                            controller: 'PostCtrl'
                        });
});
