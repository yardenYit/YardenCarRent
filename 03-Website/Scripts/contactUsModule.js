(function () {
    "use strict";

    var contactUsModule = angular.module("contactUsModule", []);

    contactUsModule.controller("ContactUsController", function ($scope, $http) {
      
        $scope.sendMsg = function () {

            //initalize ng-if messages
            //$scope.showError = false;
            //$scope.showSuccess = false;

            //passing the message data to the server
            $http({
                url: "/api/ContactUsApi",
                method: "POST",
                params: { message: $scope.message, dateTime: createDateFormat() }
            })

            .success(function (result) {              
                if (result == 1) {
                    //show success message 
                    $("#successModal").modal('show');
                    //$scope.showSuccess = true;              
                }
            })

           .error(function (err) {
               //show error message 
               $("#errorModal").modal('show');
           });
        }
    });

    //create the date in the yyyy-mm-dd hh:min:sec format
    function createDateFormat() {
        var dt = new Date();

        var month = dt.getMonth() + 1;
        var day = dt.getDate();
        var year = dt.getFullYear();
        var hour = dt.getHours();
        var minutes = dt.getMinutes();
        var seconds = dt.getSeconds();

        var now = year + '-' + month + '-' + day + ' ' + hour + ':' + minutes + ':' + seconds;
        return now;
    }

})();

