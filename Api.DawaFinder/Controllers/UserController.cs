using Api.DawaFinder.managers.Manager_User;
using Api.DawaFinder.models.User;
using Api.DawaFinder.services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DawaFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IServUser Ouser;
        public UserController(IServUser userO)
        {
            this.Ouser = userO;
        }
        [HttpGet]
        public  ActionResult getUser()
        {
            try
            {


                List<User> tab = new List<User>();
                tab = Ouser.listUser();
                return tab.Count == 0
                     ? NotFound()
                     :Ok(tab);
            }catch (Exception E)

            {
                return Problem(E.Message);

            }

        }

    }
}
