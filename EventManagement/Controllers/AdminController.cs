using BL.AdminServices;
using BL.UserServices;
using LIBRARY;
using MODELS.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManagement.Controllers
{
    public class AdminController : ApiController
    {

        [HttpPost]
        [Route("Admin/Login")]
        public HttpResponseMessage Login(ADMIN admin)
        {
            SerializeResponse<ADMIN> response = new SerializeResponse<ADMIN>();
            if (admin != null)
            {
                AdminService adminService = new AdminService();
                response = adminService.AdminOpration(admin);
            }
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("Admin/Register")]
        public HttpResponseMessage Register(ADMIN admin)
        {
            SerializeResponse<ADMIN> response = new SerializeResponse<ADMIN>();
            if (admin != null)
            {
                AdminService adminService = new AdminService();
                response = adminService.AdminOpration(admin);
            }
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
