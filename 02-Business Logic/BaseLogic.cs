using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBryce
{
    public class BaseLogic:IDisposable
    {
        protected YardenCarRentEntities db = new YardenCarRentEntities();

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
