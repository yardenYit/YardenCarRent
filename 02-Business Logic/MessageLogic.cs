using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBryce
{
    public class MessageLogic:BaseLogic
    {
        public int AddMessage(string message, DateTime dateTime)
        {
            var result = db.AddMessage(message, dateTime);
            return result;
        }
    }
}
