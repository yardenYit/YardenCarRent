(function () {
    "use strict";

    var orderHistoryModule = angular.module("orderHistoryModule", []);

    orderHistoryModule.controller("OrderHistoryController", function ($scope, $http, $localStorage) {
       
        if ($localStorage.userID == null) {// if the user role is user or employee
            window.location = "/#/homePage";
            return;
        }
        //display all the orders when the page load
        angular.element(document).ready(function () {
            $http({
                url: "/api/OrdersApi",
                method: "GET",
                params: { option: 'All'}
            })
          .success(function (result) {
              $scope.allCarsOrders = result;
              console.log(result);
          })

         .error(function (err) {
             alert("Error: " + err);
         });

        });


        //display orders by the selected option in the dropdown list
        $scope.selectedOrdersOption = function (selectedOrderItem) {
            $http({
                url: "/api/OrdersApi/",
                method: "GET",
                params: {option:selectedOrderItem}

            })

           .success(function (result) {
               $scope.allCarsOrders = result;
                             
           })

          .error(function (err) {
              alert("Error: " + err);
          });
           
        }


       
        
    });
})();