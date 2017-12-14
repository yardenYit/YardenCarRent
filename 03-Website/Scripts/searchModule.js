(function () {
    "use strict";
    var searchModule = angular.module("searchModule", []);

    //get all available cars within the dates
    searchModule.controller("SearchController", function ($scope, $http, $location, $localStorage, $sessionStorage) {

        $scope.getAllAvailableCars = function () {
            $http({
                url: "/api/SearchApi",
                method: "GET",
                params: {startDate: $scope.startDate, endDate: $scope.endDate}               
            })
         
            .success(function (result) {
               $scope.allCar4Rent = result;
               $scope.years = getYears(result);
               $scope.transmission = getTransmission(result);
               $scope.manufacture = getManufacture(result);
               $scope.model = getModel(result);              
               $scope.IsHidden = false;
               $("#successModal").modal('show');
               console.log(result);
            })

           .error(function (err) {
               $("#errorModal").modal('show');
           });
        }

        //save the reservation dates
        $scope.reservationDate = function () {
            $localStorage.startDate = $scope.startDate;
            $localStorage.endDate = $scope.endDate;           
        };

        //save the car reservation details for the reservation page
        $scope.reservationCarData = function (carData) {          
            //check ueser role
            switch ($localStorage.userRole) {
                case 1:
                    $localStorage.carReservationData = carData;
                    $location.path('/carReservation');
                    break;
                case 2:
                    $localStorage.carReservationData = carData;
                    $location.path('/carReservation');
                    break;
                case 3:
                    $localStorage.carReservationData = carData;
                    $location.path('/carReservation');
                    break;
                default:
                    alert("pls login");
                    $location.path('/homePage');
            }               
        }
    });

    //get the years of the cars that available for rent
    function getYears(result) {
        var years = [];
        for (var i = 0; i < result.length; i++) {
            years.push(result[i].Year);
        }
        return years;
    }

    //get the transmission type of the cars that available for rent
    function getTransmission(result) {
        var transmission = [];
        for (var i = 0; i < result.length; i++) {
            transmission.push(result[i].GearTypeName);
        }
        return transmission;
    }


    //get the company name of the cars that available for rent
    function getManufacture(result) {
        var manufacture = [];
        for (var i = 0; i < result.length; i++) {
            manufacture.push(result[i].CarManufactureName);
        }
        return manufacture;
    }

    //get the model name of the cars that available for rent
    function getModel(result) {
        var model = [];
        for (var i = 0; i < result.length; i++) {
            model.push(result[i].CarModelName);
        }
        return model;
    }

})();


