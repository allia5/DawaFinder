using Api.DawaFinder.services;
using Api.DawaFinder.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DawaFinder.services.UserService;
using Api.DawaFinder.models.User;

namespace Api.DawaFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService Oservice ;
        private readonly IServUser Oserv;


        public OfficeController(IOfficeService officee) => this.Oservice = officee;
       
        [HttpGet]
        public IActionResult getALL()
        {
            try
            {
                List<Office> list = new List<Office>();
                list = Oservice.getAll();
                return list.Count == 0
                    ? NotFound()
                    : Ok(list);

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public IActionResult getValue(Office offe)
        {
             try
             {
                 if (Oservice.insertoff(offe) != null) {
                     return Ok(offe);
                 }
                 return BadRequest();
             } catch (Exception e)
             {
                return Problem(e.Message); 
               /* return BadRequest();*/
            }
           


        }
        [HttpGet]
        [Route("hello")]
        public ActionResult getlistUsercontroller()
        {
            List<User> tb = new List<User>();
            try
            {
               tb= Oserv.listUser();
                return tb.Count == 0
                    ? Ok("hello")
                    : Ok(tb);

            }
            catch ( Exception e)
            {
                return BadRequest();
            }
        } 

    }
}
