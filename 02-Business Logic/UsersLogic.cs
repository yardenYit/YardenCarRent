using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBryce
{
    public class UsersLogic : BaseLogic
    {
        //add new user
        public int AddUser(string userName, string password, string firstName, string lastName,
            string identityNumber, string email, DateTime birthDate, int roleId)
        {
            var result = db.AddUser(userName, password, firstName, lastName, identityNumber, email, birthDate, roleId);
            //return result;
            if (result == 0)
                return 0;
            else
                return 1;
        }

        //check if the user is register - username and password are correct
        public int CheckIfRegister(string userName, string password)
        {
            var result = db.CheckIfRegistered(userName, password);
            var list = result.ToList();

            //return result.ToList();

            if (list.Count == 0)//if not register or user/password are incorrect
                return 0;
            else
                return list[0].UserID;
        }

        //check if userNae alredy taken
        public int CheckIfUserNameExist(string userName)
        {
            var result = db.CheckIfUserNameExist(userName);
            // return result.ToList();
            var list = result.ToList();
            if (list.Count == 0)//if the user name available 
                return 0;//1 is true
            else
                return 1;
        }

        //get user RoleID
        public int GetUserRoleID(int UserID)
        {
            var role = db.GetUserRoleID(UserID);
            var list = role.ToList();
            if (list.Count == 0)
                return 0;
            else           
                return list[0].Value;
        }
    }
}
