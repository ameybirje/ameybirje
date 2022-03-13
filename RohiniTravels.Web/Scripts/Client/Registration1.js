/// <reference path="../angular.js" />
/// <reference path="../Common.js" />


var myRTapp = angular
              .module("RegistrationModule", [])
              .controller("RegistrationControler", function ($scope, $http) {

                  $scope.message = 'hii';

                  $http.post(getServicesUrl)
                       .then(function (response) {
                           debugger;

                           var test = response.data;

                           $scope.Services = test.result;
                           

                       })

                  //var test
                  
                  //debugger;
                 
                  //WebxCommonFN.AjaxPostRequest(getServicesUrl, null ,ServicesSecFn)


                  //function ServicesSecFn(Data) {

                  //    debugger;

                  //    test = Data.result;
                  //    $scope.Services = test;
                  //    $scope.drpdpwnvalue = test[0];
    
                  //}

                  debugger;

                  

              })