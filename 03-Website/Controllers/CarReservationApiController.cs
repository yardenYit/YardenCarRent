using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace JohnBryce.Controllers
{
    public class CarReservationApiController:ApiController
    {
        public int AddReservation(int carFleetID, int userID, DateTime startDate,
            DateTime desiredEndDate)
        {
            CarsLogic cars = new CarsLogic();
            return cars.AddReservation(carFleetID, userID, startDate, desiredEndDate);
        }

        [HttpPost]
        public IHttpActionResult ReturnCar(int RentalID, DateTime actualEndDate)
        {
            CarsLogic cars = new CarsLogic();
            var results = cars.ReturnCar(RentalID, actualEndDate);
            if (results == 0)
                return NotFound();
            return Ok(results);
        }
    }
}