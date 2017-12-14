(function () {
    "use strict";

    var appModule = angular.module("appModule", ["ngRoute", "carReturnsModule","homePageModule", "searchModule",
        "signupModule", "contactUsModule", "carReservationModule", "userOrderHistoryModule",
        "fleetManagementModule", "orderHistoryModule", 'ui.filters', 'ui.bootstrap', 'ngStorage', 'ngMessages', 'ngTable', 'ngResource',"xeditable"]);
 
    appModule.controller("LoginController", function ($scope, $http, $sessionStorage, $window, $route, $location, $localStorage,$timeout) {

        //if the user isn't logged in
        if ($localStorage.userID == null) {
            $('#carReservation').hide();
            $('#orderHistory').hide();
            $('#mangaerMenu').hide();
            $('#employeeMenu').hide();
            $("#logOut").hide();
        }

        //if the user is registered -get his role
        else {
            $http({
                url: "/api/SignupApi/GetUserRoleID",
                method: "GET",
                params: { UserID: $localStorage.userID }
            })

           .success(function (result) {              
               $("#signIn").hide();
               $localStorage.userRole = result;
               var userRole = $localStorage.userRole;
              
               if (userRole == 2) { //if user is an employee
                   $('#mangaerMenu').hide();
               }

               if (userRole == 3) {// if the user is register
                   $('#mangaerMenu').hide();
                   $('#employeeMenu').hide();
               }
           })

          .error(function (err) {
              alert("Error: " + err);
          });
        }

        //user log in 
        $scope.signIn = function () {
            //closing the sign up menu
            $(".dropdown-toggle").dropdown("toggle");

            $("#signIn").hide();
            $("#logOut").show();

            $http({
                url: "/api/SignupApi/CheckIfRegister",
                method: "GET",
                params: { userName: $scope.userName, password: $scope.password }
            })
         
            .success(function (result) {
                $localStorage.userID = result;
                $localStorage.userName = $scope.userName;

                $("#successModal").modal('show');

                $timeout(function () {
                    // 2 second delay for modal.
                    $window.location.reload();
                }, 2000);
            })

           .error(function (err) {
               $("#errorModal").modal('show');
               $("#signIn").show();
               $("#logOut").hide();

               //reset input values
               $("#userName").val("");
               $("#password").val("");
           });       
        }
       
        //logout section
        $("#logOut").click(function () {
            $("#signIn").show();
            $("#logOut").hide();
            $('#carReservation').hide();
            $('#orderHistory').hide();
            $('#mangaerMenu').hide();
            $('#employeeMenu').hide();

            //reset input values
            $("#userName").val("");
            $("#password").val("");

            //clear sessionStorage
            localStorage.clear();

            $window.location= '#/homePage';
        });
    });

    //routing
    appModule.config(function ($routeProvider) {
        $routeProvider
            .when("/homePage", {
                templateUrl: "/HTML/homePage.html",
                controller: "HomePageController"
            })
            .when("/search", {
                templateUrl: "/HTML/search.html",
                controller: "SearchController"
            })

            .when("/carReservation", {
                templateUrl: "/HTML/carReservation.html",
                controller: "CarReservationController"
            })

             .when("/fleetManagement", {
                 templateUrl: "/HTML/fleetManagement.html",
                 controller: "FleetManagementController"
             })

             .when("/carReturns", {
                 templateUrl: "/HTML/carReturns.html",
                 controller: "CarReturnsController"
             })

             .when("/orderHistory", {
                 templateUrl: "/HTML/orderHistory.html",
                 controller: "OrderHistoryController"
             })

             .when("/userOrderHistory", {
                 templateUrl: "/HTML/userOrderHistory.html",
                 controller: "UserOrderHistoryController"
             })


            .when("/signup", {
                templateUrl: "/HTML/signup.html",
                controller: "SignupController"
            })

             .when("/contactUs", {
                 templateUrl: "/HTML/contactUs.html",
                 controller: "ContactUsController"
             })

         //default route
        .otherwise({
            redirectTo: "/homePage"
        });
    });

  
})();