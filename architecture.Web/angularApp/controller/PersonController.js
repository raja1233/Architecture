/// <reference path="../../Scripts/angular.js" />
/// <reference path="../FactoryServices/FactoryServices.js" />
(function () {
    angular.module("architectureApp", ['ui.router']);

    angular.module("architectureApp")
            .controller("PostCtrl", ['$scope', '$location', '$state', '$stateParams', 'ArchitectureService',
                function ($scope, $location, $state, $stateParams, ArchitectureService) {

                var ID= $stateParams.id;
                console.log(ID);
               
                $scope.submit = function Submit(data) {
                    ArchitectureService.PostCall(data).then(function (response) {
                        $scope._Promise = response.data;
                        $location.path('/');
                    });
                };
                //Redirect to the specified page
                $scope.go = function (url) { 
                    $location.path(url);    
                };

                //get all data from the database
                $scope.getData = function () { 
                    ArchitectureService.getCall().then(function (response) {
                        $scope._PromiseGet = response.data; 
                    });
                };
                $scope.getData();
                //get data by id
                $scope.EditData = function () {    
                    ArchitectureService.getByIdCall(ID).then(function (response) {
                        $scope.getIdParams = response.data; 
                    });
                    
                };
                $scope.EditData();
                //delete data by id
                $scope.delete = function (id) {   
                    ArchitectureService.deleteCall(id).then(function (response) {
                        $scope.deletedItem = response;
                        $scope.getData();
                    });
                   
                };
              
                //save user change data
                $scope.updateAll = function (data) {
                    ArchitectureService.update(data).then(function (response) {
                        $scope.updateParams = response.data;
                        $location.path('/');
                    });
                };
                $scope.OpenPdfPopup = function (event, value) {
                    //getDiagnosisDetail(value);
                   

                    $("#example1").css('height', '500px');
                    debugger;
                    var url = "http://localhost:60735/#/PDF/Accounts Transactions Business Logic amendments.pdf";
                    // var url = "http://localhost:58836" + value.split('..')[1];
                    PDFObject.embed(url, "#example1");
                }
                //this.isOpen = false;
                }]);

})();

