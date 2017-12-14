using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JohnBryce.Controllers
{
    public class SearchApiController : ApiController
    {
        //get all the cars that are ok to rent between startDate and endDate
        public IEnumerable GetAllCars(DateTime startDate, DateTime endDate)
        {
            CarsLogic cars = new CarsLogic();

            return cars.GetAllCars(startDate, endDate);
        }     
    }
}
