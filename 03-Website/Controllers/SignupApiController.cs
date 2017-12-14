using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace JohnBryce.Controllers
{
    public class SignupApiController : ApiController
    {
        //adding a new user deatails
        [HttpPost]
        [ActionName("AddUser")]
        public IHttpActionResult AddUser(string userName, string password, string firstName, string lastName,
            string identityNumber, string email, DateTime birthDate, int roleId)
        {
            UsersLogic users = new UsersLogic();
            var results= users.AddUser(userName, password, firstName, lastName, identityNumber, email, birthDate, roleId);
            if (results == 0)
                return NotFound();
            else
                return Ok(results);

        }

        //check if the user is register - username and password are correct
        [HttpGet]
        [ActionName("CheckIfRegister")]
        public IHttpActionResult CheckIfRegister(string userName, string password)
        {
            UsersLogic users = new UsersLogic();
            var results = users.CheckIfRegister(userName, password);
            if (results == 0)
                return NotFound();
            else
                return Ok(results);
        }

        //check if userName already taken
        [HttpGet]        
        [ActionName("CheckIfUserNameExist")]
        public IHttpActionResult CheckIfUserNameExist(string userName)
        {
            UsersLogic users = new UsersLogic();
            var result = users.CheckIfUserNameExist(userName);
            if (result == 1)
                return Ok(result);
            else
                return NotFound();

        }

        //get the user RoleID
        [HttpGet]
        [ActionName("GetUserRoleID")]
        public IHttpActionResult GetUserRoleID(int UserID)
        {
            UsersLogic users = new UsersLogic();
            var role = users.GetUserRoleID(UserID);
            if (role == 0)
                return NotFound();
            else
                return Ok(role);
        }
    }
}