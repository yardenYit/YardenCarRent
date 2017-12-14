using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace JohnBryce.Controllers
{
    public class ContactUsApiController:ApiController
    {
        
        public int AddMessage(string message, DateTime dateTime)
        {
            MessageLogic messages = new MessageLogic();
       
            return messages.AddMessage(message, dateTime);
        }
    }
}