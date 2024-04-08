using BL.EventServices;
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
    public class EventInfoController : ApiController
    {
        [HttpPost]
        [Route("EventInfo/AddEvent")]
        public HttpResponseMessage AddEvent(EVENTINFO eventInfo)
        {
            SerializeResponse<EVENTINFO> response = new SerializeResponse<EVENTINFO>();
            if(eventInfo != null)
            {
                EventInfoService eventInfoService=new EventInfoService();
                response=eventInfoService.EventInfoOpration(eventInfo);
            }
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("EventInfo/GetAllEvent")]
        public HttpResponseMessage GetAllEvent(EVENTINFO eventInfo)
        {
            SerializeResponse<EVENTINFO> response=new SerializeResponse<EVENTINFO>();
            if (eventInfo != null)
            {
                EventInfoService eventInfoService =new EventInfoService();
                response = eventInfoService.EventInfoOpration(eventInfo);
                
            }
            return this.Request.CreateResponse(HttpStatusCode.OK,response);
        }
       
    }
}
