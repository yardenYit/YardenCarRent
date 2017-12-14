using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace JohnBryce.Controllers
{
    public class OrdersApiController : ApiController
    {
        //get all clients orders
        public IEnumerable GetAllOrders(string option)
        {
            OrdersLogic orders = new OrdersLogic();
            switch (option)
            {
                case "All":
                    return orders.GetAllOrders();
                case "Open":
                    return orders.GetAllOpenOrders();
                case "Closed":
                    return orders.GetAllClosedOrders();
                default:
                    return orders.GetAllOrders();
            }
        }

        //get all the login user orders
        public IEnumerable GetAllMyOrders(int userID)
        {
            OrdersLogic orders = new OrdersLogic();
            return orders.GetAllMyOrders(userID);
        }
    }
}