(function () {
    "use strict";

    var carReturnsModule = angular.module("carReturnsModule", []);

    carReturnsModule.controller("CarReturnsController", function ($scope, $http, $route, $timeout, $localStorage) {
             
        // if the user role is user or the use didn't log in
        if (($localStorage.userRole == 3)|| ($localStorage.userID == null))  {
            window.location = "/#/homePage";
            return;
        }

        $scope.actualEndDate = new Date();

        //display all the open orders when the page load
        angular.element(document).ready(function () {
            $http({
                url: "/api/OrdersApi",
                method: "GET",
                params: { option: 'Open' }
            })
                
          .success(function (result) {
              $scope.allOpenOrders = result;
          })

         .error(function (err) {
             alert("Error: " + err);
         });

        });

        //return a car
        $scope.returnCar = function (carData) {
            $http({
                url: "/api/CarReservationApi",
                method: "POST",
                params: { rentalID: carData.RentalID, actualEndDate: $scope.actualEndDate }
            })

           .success(function (result) {
               $("#successModal").modal('show');
               $timeout(function () {
                   // 2 second delay for modal.
                   $route.reload();
               }, 3000);
           })

          .error(function (err) {
              $("#errorModal").modal('show');
          });
        }

    });
})();