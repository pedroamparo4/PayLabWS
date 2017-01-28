using PayLabWS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace PayLabWS.Controllers
{
    public class PaymentController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/time")]
        public IHttpActionResult Get()
        {
            return Ok($"Server time: {DateTime.Now.ToString()}");
        }

        [AuthorizeAttribute]
        [HttpGet]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok($"Welcome {identity.Name}");
        }

        [AuthorizeAttribute(Roles = "admin")]
        [HttpGet]
        [Route("api/data/authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(s => s.Value);

            return Ok($"Welcome {identity.Name} Role: {string.Join(",", roles.ToList())}");
        }

        [AuthorizeAttribute(Roles = "admin")]
        [HttpPost]
        [Route("api/data/makepayment")]
        public IHttpActionResult MayPayment(Payment input)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(s => s.Value);
            
            return Ok($"Payment applied succesfully on PayLab");
        }

    }
}
