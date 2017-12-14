
(function () {
    "use strict";

    var fleetManagementModule = angular.module("fleetManagementModule", []);
   
    fleetManagementModule.controller("FleetManagementController", function ($scope, $http, NgTableParams, $localStorage, $route, $timeout) {

        if (($localStorage.userRole == 3) || ($localStorage.userRole == 2) || (($localStorage.userID == null))) {// if the user role is user or employee
            window.location = "/#/homePage";
            return;
        }

        var newRow = false;

        $scope.cancel = cancel;
        $scope.save = save;
        $scope.del = del;

        
        //display all the car fleet data when the page load
        $http({
            url: "/api/FleetManagementApi/GetAllCarFleet",
            method: "GET"
        })
         .success(function (result) {
             console.log(result);
             $scope.tableParams = new NgTableParams({
                 page: 1,
                 count: 10
             }, {
            
                 dataset: result
             });

             //saving the original data            
             $localStorage.originalData = result;                                           
         })
        .error(function (err) {
            alert("Error: " + err);
        });

        var originalData = $localStorage.originalData;

        //cancel row editing 
        function cancel(row, rowForm) {
            var originalRow = resetRow(row, rowForm, originalData);
            angular.extend(row, originalRow);
            row.isEditing = false;
            $route.reload();
        }

        //reset the row data to the original data
        function resetRow(row, rowForm, originalData) {
            row.isEditing = false;
            rowForm.$setPristine();            
            for (let i in originalData) {
                if (originalData[i].id === row.id) {
                    return originalData[i]
                }
            }    
        }
       
        //get carModelId value of selected data
        var carModelId = '';
        $scope.changedCarModelValue = function (item) {
            carModelId = item.CarModelID;
        }

        //get CarManufactureId value of selected data
        var carManufactureId = '';
        $scope.changedCarManufactureValue = function (item) {
            carManufactureId = item.CarManufactureID;
        }

        //save the data at the db
        function save(row, rowForm) {
            var okToRent = '';
            var gearTypeId = '';

            if (row.IsOK2Rent == 1) {
                okToRent = true;
            }
            else {
                okToRent = false;
            }

            if(row.GearTypeName=='Automatic'){
                gearTypeId=1;
            }
            else{
                gearTypeId=2;
            }

            if (!newRow){//update row            
                $http({
                    url: "/api/FleetManagementApi/UpdateCarFleet",
                    method: "POST",
                    params: {
                        carFleetID: row.CarFleetID,
                        carNumber: row.CarNumber,
                        currentMiles: row.CurrentMiles,
                        imageFileName: row.ImageFileName,
                        isOK2Rent: okToRent,
                        carModelID: carModelId,
                        carManufactureID: carManufactureId,
                        carManufactureName: row.CarManufactureName,
                        carModelName: row.CarModelName,
                        carTypeID: row.CarTypeID,
                        dailyCost: row.DailyCost,
                        dailyLateCost: row.DailyLateCost,
                        gearTypeID: gearTypeId,
                        year: row.Year
                    }
                })
                .success(function (manufactureResult) {
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
                //add new row
            else {
                $http({
                    url: "/api/FleetManagementApi/AddCar",
                    method: "POST",
                    params: {
                        carNumber: row.CarNumber,
                        currentMiles: row.CurrentMiles,
                        imageFileName: row.ImageFileName,
                        isOK2Rent: okToRent,
                        carModelID: carModelId,                                                                  
                        dailyCost: row.DailyCost,
                        dailyLateCost: row.DailyLateCost,
                        gearTypeID: gearTypeId,
                        year: row.Year
                    }
                })
                 .success(function (result) {
                     $("#successModal").modal('show');
                     $timeout(function () {
                         // 2 second delay for modal.
                         $route.reload();
                     }, 2000);
                 })
                   .error(function (err) {
                       $("#errorModal").modal('show');
                   });

                newRow = false;
            }
        }


        function del(row) {          
            //delete old row
            if (!newRow) {
                $http({
                    url: "/api/FleetManagementApi/DeleteCarFleet",
                    method: "DELETE",
                    params: {
                        carFleetID: row.CarFleetID
                    }
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
            //delete new empty row               
            else {
                $scope.tableParams.data.pop();
                newRow = false;
                }
            }
  
        //add new empty row 
        $scope.addCarFleet = function addCarFleet(tableParams) {
            console.log("hi");
            newRow = true;
           
            $scope.tableParams.data.push({
                'CarManufactureName': "",
                'CarModelName': "",
                'CarNumber': "",
                'CurrentMiles': "",
                'DailyCost': "",
                'DailyLateCost': "",
                'GearTypeName': "",
                'ImageFileName': "",
                'IsOK2Rent': "",
                'Year': "",                
            });                   
        }

        //get the Manufacture names to the select list
        $scope.getManufacture = function getManufacture() {
            $http({
                url: "/api/FleetManagementApi/GetAllManufactureName",
                method: "GET"
            })
            .success(function (manufactureResult) {               
                $scope.manufacturers = getManufactureList(manufactureResult);         
            })
            .error(function (err) {
                alert("Error: " + err);
            });
        }
      
        function getManufactureList(manufacturerResult) {
            var manufacturers = [];
            for (var i = 0; i < manufacturerResult.length; i++) {
                manufacturers.push(manufacturerResult[i]);
            }
            return manufacturers;
        }


        //get the model names to the select list
        $scope.getModel = function getModel() {
            $http({
                url: "/api/FleetManagementApi/GetAllModelName",
                method: "GET"
            })
            .success(function (modelResult) {
                $scope.model = getModelList(modelResult);            
            })
            .error(function (err) {
                alert("Error: " + err);
            });
        }

        function getModelList(modelResult) {          
            var models = [];
            for (var i = 0; i < modelResult.length; i++) {
                models.push(modelResult[i]);
            }
            return models;
        }
      
        $scope.getCarImages = function getCarImages() {
            $scope.imgaes = ["Accent.jpg", "Corolla.jpg", "I30.jpg", "Yaris.jpg"];
        }

        //get the gear types to the select list
        $scope.getGearTypes = function getGearTypes() {
            $http({
                url: "/api/FleetManagementApi/GetAllGearTypes",
                method: "GET"
            })
            .success(function (gearResult) {           
                $scope.transmission = getGearList(gearResult);
            })
            .error(function (err) {
                alert("Error: " + err);
            });
        }

        function getGearList(gearResult) {
            var gears = [];
            for (var i = 0; i < gearResult.length; i++) {
                gears.push(gearResult[i]);
            }
            return gears;
        }

    //end of controller
    });

})();