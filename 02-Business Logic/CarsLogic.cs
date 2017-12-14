using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Runtime.Serialization;

namespace JohnBryce
{
    public class CarsLogic : BaseLogic
    {

        //get all the car that are ok to rent 
        public IEnumerable GetAllCars(DateTime startDate, DateTime endDate)
        {
            var result = db.GetAvailableCars4Rent(startDate, endDate);
            return result.ToList();
        }

        //insert the data of the rental car
        public int AddReservation(int carFleetID, int userID, DateTime startDate, DateTime desiredEndDate)
        {
            var result = db.AddReservation(carFleetID, userID, startDate, desiredEndDate);
            return result;
        }


        //return a car
        public int ReturnCar(int RentalID, DateTime actualEndDate)
        {
            var result = db.ReturnCar(actualEndDate, RentalID);
            return result;
        }

        //get all the cars in the fleet
        public IEnumerable GetAllCarFleet()
        {
            var result = db.GetAllCarFleet();
            return result.ToList();
        }

        //get all the manufacture Names

        public IEnumerable GetAllManufactureName()
        {
            var result = db.GetAllManufactureName();
            return result.ToList();
        }


        //get all the manufacture Names
        public IEnumerable GetAllModelName()
        {
            var result = db.GetAllModelName();
            return result.ToList();
        }


        //get all cars images
        public IEnumerable GetAllCarImages()
        {
            var result = db.GetAllCarImages();
            return result.ToList();
        }

        //get all gear types
        public IEnumerable GetAllGearTypes()
        {
            var result = db.GetAllGearTypes();
            return result.ToList();
        }


        //adding a car to the fleet management
        public int AddCar(string carNumber, int currentMiles, string imageFileName, bool isOK2Rent,
            int carModelID, int year, int gearTypeID, int dailyCost, int dailyLateCost)
        {
            var result = 0;
            try
            {
                result = db.AddCar(carNumber, currentMiles,  imageFileName,  isOK2Rent,
                            carModelID, year, gearTypeID, dailyCost, dailyLateCost);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }


        //update a car to the fleet management
        public int UpdateCarFleet(int carFleetID, string carNumber, int currentMiles, string imageFileName, bool isOK2Rent,
            int carTypeID, int carModelID, int year, int gearTypeID, int dailyCost, int dailyLateCost, int carManufactureID,
            string carModelName, string carManufactureName)
        {
            var result = 0;
            try
            {
                result = db.UpdateCarFleet(carFleetID, carNumber, currentMiles, imageFileName, isOK2Rent,
                    carTypeID, carModelID, year, gearTypeID, dailyCost, dailyLateCost, carManufactureID,
                    carModelName, carManufactureName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        //delete a car to the fleet management if the car has no orders
        public int DeleteCarFleet(int carFleetID)
        {
            var result = db.DeleteCarFleet(carFleetID);
            return result;
        }

        //public int CheckIfRent(int carFleetID)
        //{
        //    var result = db.CheckIfRent(carFleetID);
        //    var list = result.ToList();
        //    if (list.Count==0)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return 1;
        //    }
        //}




    }
}


