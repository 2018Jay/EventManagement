using BL.ActivityInfoServices;
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
    public class ActivityInfoController : ApiController
    {
        [HttpPost]
        [Route("ActivityInfo/AddActivity")]
        public HttpResponseMessage AddActivity(ACTIVITYINFO activityInfo)
        {
            SerializeResponse<ACTIVITYINFO> response = new SerializeResponse<ACTIVITYINFO>();
            if(activityInfo != null)
            {
                ActivityInfoService activityInfoService = new ActivityInfoService();
                response=activityInfoService.ActivityInfoOpration(activityInfo);
            }
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("ActivityInfo/GetAllActivity")]
        public HttpResponseMessage GetAllActivity(ACTIVITYINFO activityInfo)
        {
            SerializeResponse<ACTIVITYINFO> response = new SerializeResponse<ACTIVITYINFO>();
            if (activityInfo != null)
            {
                ActivityInfoService activityInfoService = new ActivityInfoService();
                response = activityInfoService.ActivityInfoOpration(activityInfo);
            }
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("ActivityInfo/GetActivityByEventId")]
        public HttpResponseMessage GetActivityByEventId(ACTIVITYINFO activityInfo)
        {
            SerializeResponse<ACTIVITYINFO> response = new SerializeResponse<ACTIVITYINFO>();
            if (activityInfo != null)
            {
                ActivityInfoService activityInfoService = new ActivityInfoService();
                response = activityInfoService.ActivityInfoOpration(activityInfo);
            }
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }
}
