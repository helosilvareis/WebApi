using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private static List<UserModel> userList = new List<UserModel>();
        
        [AcceptVerbs("POST")]
        [Route("CreateUser")]
        public string CreateUser(UserModel user)
        {
            userList.Add(user);

            return "User created!";
        }

        [AcceptVerbs("PUT")]
        [Route("EditUser")]
        public string EditUser(UserModel user)
        {
            userList.Where(_ => _.ID == user.ID)
                         .Select(s =>
                         {
                             s.ID = user.ID;
                             s.Login = user.Login;
                             s.Name = user.Name;

                             return s;

                         }).ToList();

            return "User changed!";
        }

        public string DeleteUser(int ID)
        {
            UserModel user = userList.Where(_ => _.ID == ID)
                .Select(_ => _)
                .First();

            userList.Remove(user);

            return "User deleted!";
        }

        public List<UserModel> GetUsers()
        {
            userList.Add(new UserModel { ID = 1, Login = "UserOne", Name = "User One" });
            userList.Add(new UserModel { ID = 2, Login = "UserTwo", Name = "User Two" });
            userList.Add(new UserModel { ID = 3, Login = "UserThree", Name = "User Three" });
            return userList;
        }
    }
}
