(function () {
    "use strict";

    var carReservationModule = angular.module("carReservationModule", []);

    carReservationModule.controller("CarReservationController", function ($scope, $http, $localStorage, $sessionStorage, $timeout) {

        // if the user role is user or the use didn't log in
        if ($localStorage.userID == null){
            window.location = "/#/homePage";
            return;
        }

        //Bringing car reservation data
        $scope.startDate = $localStorage.startDate;
        $scope.endDate = $localStorage.endDate;
        $scope.carData = $localStorage.carReservationData;
      
        //if no car was choosen
        if ($localStorage.carReservationData == null) {
            alert("Please choose a car to rent");
            window.location = "/#/search";
        }
       
        $scope.addReservation = function () {
            $http({
                url: "/api/CarReservationApi",
                method: "POST",
                params: {
                    carFleetID: $scope.carData.CarFleetID,
                    userID: $localStorage.userID,
                    startDate: $scope.startDate,
                    desiredEndDate: $scope.endDate,
                }                  
            })
            .success(function (result) {
                $("#successModal").modal('show');               
                $localStorage.carReservationData = null;
              
                $timeout(function () {
                    // 2 second delay for modal.
                    window.location = "/#/search";
                }, 4000);              
            })

           .error(function (err) {
               $("#errorModal").modal('show');
           });
        }
    
    });

})();

