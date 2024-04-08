using BL.UserServices;
using LIBRARY;
using MODELS.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;

namespace EventManagement.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("User/Login")]
       public HttpResponseMessage Login(USER user)
        {
            SerializeResponse<USER> response=new SerializeResponse<USER> ();
            if(user != null )
            {
                UserService userService = new UserService ();
                response= userService.UserOpration(user);
            }
            return this.Request.CreateResponse(HttpStatusCode.OK,response);
        }

        [HttpPost]
        [Route("User/Register")]
        public HttpResponseMessage Register(USER user)
        {
            SerializeResponse<USER> response = new SerializeResponse<USER>();
            if (user != null)
            {
                UserService userService = new UserService();
                response = userService.UserOpration(user);
            }
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
