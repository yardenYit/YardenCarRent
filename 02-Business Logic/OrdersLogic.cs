using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBryce
{
    public class OrdersLogic:BaseLogic
    {
        //get all clients orders 
        public IEnumerable GetAllOrders()
        {
            var result = db.GetAllOrders();
            return result.ToList();
        }

        //get all the open orders 
        public IEnumerable GetAllOpenOrders()
        {
            var result = db.GetAllOpenOrders();
            return result.ToList();
        }

        //get all the closed orders 
        public IEnumerable GetAllClosedOrders()
        {
            var result = db.GetAllCloseOrders();
            return result.ToList();
        }

        //get all the login user orders
        public IEnumerable GetAllMyOrders(int userID)
        {
            var result = db.GetAllMyOrders(userID);
            return result.ToList();
        }

    }
}
