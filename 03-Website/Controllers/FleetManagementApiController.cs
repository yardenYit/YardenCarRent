using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace JohnBryce.Controllers
{
    public class FleetManagementApiController : ApiController
    {
        //get all car fleet data
        [ActionName("GetAllCarFleet")]
        public IEnumerable GetAllCarFleet()
        {
            CarsLogic cars = new CarsLogic();
            return cars.GetAllCarFleet();
        }

        //get all the manufacture Names       
        [ActionName("GetAllManufactureName")]
        public IEnumerable GetAllManufactureName()
        {
            CarsLogic cars = new CarsLogic();
            return cars.GetAllManufactureName();
        }

        //get all the model Names
        [ActionName("GetAllModelName")]
        public IEnumerable GetAllModelName()
        {
            CarsLogic cars = new CarsLogic();
            return cars.GetAllModelName();
        }

        //get all cars images
        [ActionName("GetAllCarsImages")]
        public IEnumerable GetAllCarsImages()
        {
            CarsLogic cars = new CarsLogic();
            return cars.GetAllCarImages();
        }

        //get all gear types
        [ActionName("GetAllGearTypes")]
        public IEnumerable GetAllGearTypes()
        {
            CarsLogic cars = new CarsLogic();
            return cars.GetAllGearTypes();
        }

        //update the car fleet data
        [HttpPost]
        [ActionName("UpdateCarFleet")]
        public int UpdateCarFleet(int carFleetID, string carNumber, int currentMiles,
            string imageFileName, bool isOK2Rent, int carTypeID, int carModelID, int year, int gearTypeID, int dailyCost,
            int dailyLateCost, int carManufactureID, string carModelName, string carManufactureName)
        {
            CarsLogic cars = new CarsLogic();
            return cars.UpdateCarFleet(carFleetID, carNumber, currentMiles, imageFileName, isOK2Rent,
                    carTypeID, carModelID, year, gearTypeID, dailyCost, dailyLateCost, carManufactureID,
                    carModelName, carManufactureName);
        }


        [HttpDelete]
        [ActionName("DeleteCarFleet")]
        public IHttpActionResult DeleteCarFleet(int carFleetID)
        {
            CarsLogic cars = new CarsLogic();
            var result = cars.DeleteCarFleet(carFleetID);
            if (result == 1)//there are no orders for this carID
                return Ok(result);
            else
                return NotFound();
        }

        //[HttpGet]
        //[ActionName("CheckIfRent")]
        //public IHttpActionResult CheckIfRent(int carFleetID)
        //{
        //    CarsLogic users = new CarsLogic();
        //    var result = users.CheckIfRent(carFleetID);
        //    if (result == 0)
        //        return Ok(result);
        //    else
        //        return NotFound();
        //}

        //delete



        //add car to car fleet

        [HttpPost]
        [ActionName("AddCar")]
        public IHttpActionResult AddCar(string carNumber, int currentMiles, string imageFileName, bool isOK2Rent,
            int carModelID, int year, int gearTypeID, int dailyCost, int dailyLateCost)
        {
            CarsLogic cars = new CarsLogic();
            var result = cars.AddCar( carNumber, currentMiles,  imageFileName, isOK2Rent,
             carModelID, year, gearTypeID, dailyCost, dailyLateCost);
            if (result == 2)
                return Ok(result);
            else
                return NotFound();
        }
    }
}