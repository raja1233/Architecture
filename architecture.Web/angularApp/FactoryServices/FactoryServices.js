/// <reference path="../../Scripts/angular.js" />

angular.module("architectureApp").service("ArchitectureService", function ($http) {
    var result;
    var _service = this;
 
    //This method is for post the user details
    _service.PostCall = function (user) {
      var  request = $http({
            url: "http://localhost:60735/api/PersonApi",
            method: "Post",
            dataType: 'json',
            data: user,
            headers: {
                "Content-Type": "application/json"
            }
        });
        return request;
    };

    this.getCall=function()
    {
        debugger;
       
        var request = $http({
            url: "http://localhost:60735/api/PersonApi",
            method: "get",
           
        });
        return request;
    }
    //this method is for get data regarding as id of the user
    this.getByIdCall = function (id)
    { 
        var request = $http({
            url: "http://localhost:60735/api/personapi/"+id,
            method: "get",
        });
     
        return request;
    }

    //code to delete data from the 
    this.deleteCall = function (id) {

        var request = $http({
            url: "http://localhost:60735/api/PersonApi/" + id,
            method: "delete",
        });
        return request;
    };



    //code to update data from database
    this.update=function(user)
    {
        var request = $http({
            url: "http://localhost:60735/api/PersonApi",
            method: "put",
            data: user,
            dataType: 'json',
            headers: {
                "Content-Type": "application/json"
            }
        });
        return request;
    }
});