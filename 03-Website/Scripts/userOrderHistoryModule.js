(function () {
    "use strict";

    var orderHistoryModule = angular.module("userOrderHistoryModule", []);

    orderHistoryModule.controller("UserOrderHistoryController", function ($scope, $http, $localStorage, $location) {

        if ($localStorage.userID == null) {
            alert("pls login");
            $location.path('/homePage');
        }
        else
        {
            //display all the orders when the page load
            angular.element(document).ready(function () {
                $http({
                    url: "/api/OrdersApi",
                    method: "GET",
                    params: { userID: $localStorage.userID }
                })
              .success(function (result) {
                  $scope.allCarsOrders = result;                
              })

             .error(function (err) {
                 alert("Error: " + err);
             });

            });
        }
      
    });
})();