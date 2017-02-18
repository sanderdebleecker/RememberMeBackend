using RememberMeBackend.Data;
using RememberMeBackend.Data.Actions;
using RememberMeBackend.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RememberMeBackend.Controllers {
    public class UserController : ApiController {

        public UserController() {
        }

        [HttpGet]
        public IEnumerable<ApplicationUser> All() {
            IEnumerable<ApplicationUser> users;
            using (var unitOfWork = new UnitOfWork(new MemoryDbContext())) {
                users = unitOfWork.Users.GetAll();
                Console.WriteLine(users.Count());
            }
            return users;
        }
    }
}
