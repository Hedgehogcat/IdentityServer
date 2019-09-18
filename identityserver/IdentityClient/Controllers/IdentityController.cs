using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityClient
{
    public class IdentityController : Controller
    {
        [Authorize]
        [HttpGet]
        [Route("socialnetwork")]
        public IActionResult Get()
        {
            var username = User.Claims.First(x => x.Type == "email").Value;
            return Ok(username);
            //return new JsonResult(from c in User.Claims select new { c.Type, c.Value});
        }
    }
}
