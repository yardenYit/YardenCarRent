(function () {
    "use strict";

    var signupModule = angular.module("signupModule", []);

    //Checking age above 18
    signupModule.directive('age', function () {       

        //closing the sign up menu        
        $("a.signUp").click(function () {
            $("#signIn").dropdown("toggle");
        });
      
        return {
            require: 'ngModel',
            link: function (scope, elm, attrs, ctrl) {
                ctrl.$validators.age = function (modelValue, viewValue) {
                    if (ctrl.$isEmpty(modelValue)) {
                        // consider empty models to be valid
                        return true;
                    }

                    var minAge = 18;

                    //get the year,month and day of the selected birthdate
                    var split = modelValue.split('/');
                    var year = split[2];
                    var day = split[1];
                    var month = split[0];
                  
                    var today = new Date();
              
                    var difYear = today.getFullYear() - year;
                    var difMonth = Math.abs(month - (today.getMonth() + 1));
                    var difDay = Math.abs(day - today.getDate());

                    var difference = difYear;
                   
                    // it is invalid
                    if (difference < minAge)
                        return false;
                    else
                        return true;
                };
            }
        };
    });


    //Checking the validation of the identity number   
    signupModule.directive('identity', function () {
        return {
            require: 'ngModel',
            link: function (scope, elm, attrs, ctrl) {
                ctrl.$validators.identity = function (modelValue, viewValue) {
                    if (ctrl.$isEmpty(modelValue)) {
                        // consider empty models to be invalid
                        return false;
                    }

                    if (IDValidator(viewValue)) {
                        // it is valid
                        return true;
                    }

                    // it is invalid
                    return false;
                };
            }
        };
    });



    //adding a new user
    signupModule.controller("SignupController", function ($scope, $http) {
        $scope.addUser = function () {

            //check if there is an email value
            //var email = '';
            //if ($scope.email) {
            //    email = $scope.email;
            //}

            ////check if there is a birthDate value
            //var birthDate = '';
            //if ($scope.birthDate) {
            //    birthDate = $scope.birthDate;
            //}
           
            //send the data to the server
            $http({
                url: "/api/SignupApi/AddUser",
                method: "POST",
                params: {
                    userName: $scope.userName,
                    password: $scope.password,
                    firstName: $scope.firstName,
                    lastName: $scope.lastName,
                    identityNumber: $scope.identityNumber,
                    email: $scope.email,
                    birthDate: $scope.birthDate,
                    roleId: '3'
                }
            })
                               
            .success(function (result) {              
                $("#successModal").modal('show');
            })

           .error(function (err) {
               $("#errorModal").modal('show');
           });
        }
    });


    //validatin for identity number
    function IDValidator(id) {
        id += "";//casting to string

        //check input length
        if (id.length != 9 || isNaN(id)) {
            return false;
        }

        var counter = 0;
        for (var i = 0; i < 8; i++) {
            var x = (((i % 2) + 1) * id.charAt(i));
            if (x > 9) {
                x = x.toString();
                x = parseInt(x.charAt(0)) + parseInt(x.charAt(1))
            }
            counter += x;
        }

        if ((counter + parseInt(id.charAt(8))) % 10 == 0) {
            return true;
        }
        else {
            return false;
        }
    }

})();