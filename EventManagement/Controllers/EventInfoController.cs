using BL.EventServices;
using LIBRARY;
using MODELS.MODELS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
                try
                {
                    eventInfo.Publish = false;
                    string path = AppDomain.CurrentDomain.BaseDirectory + "Images\\EventImages\\"+ eventInfo.EventName+"_"+ DateTime.Now.Ticks + ".jpg";



                    byte[] bytes = Convert.FromBase64String(eventInfo.EventImgPath);

                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        Image pic = Image.FromStream(ms);

                        pic.Save(path);
                    }
                    eventInfo.EventImgPath = path;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
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

        [HttpPost]
        [Route("EventInfo/GetEventById")]
        public HttpResponseMessage GetEventById(EVENTINFO eventInfo)
        {
           
            SerializeResponse<EVENTINFO> response = new SerializeResponse<EVENTINFO>();
            if (eventInfo != null)
            {
                EventInfoService eventInfoService = new EventInfoService();
                response = eventInfoService.EventInfoOpration(eventInfo);

            }
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("EventInfo/GetNotPublishEvents")]
        public HttpResponseMessage GetNotPublishEvents(EVENTINFO eventInfo)
        {

            SerializeResponse<EVENTINFO> response = new SerializeResponse<EVENTINFO>();
            if (eventInfo != null)
            {
                EventInfoService eventInfoService = new EventInfoService();
                response = eventInfoService.EventInfoOpration(eventInfo);

            }
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("EventInfo/UpdateEventByEventId")]
        public HttpResponseMessage UpdateEventByEventId(EVENTINFO eventInfo)
        {

            SerializeResponse<EVENTINFO> response = new SerializeResponse<EVENTINFO>();
            if (eventInfo != null)
            {
                EventInfoService eventInfoService = new EventInfoService();
                response = eventInfoService.EventInfoOpration(eventInfo);

            }
            return this.Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }
}
