using Ocupado_WebServer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ocupado_WebServer.Controllers {
    [RoutePrefix("api/SensorUpdate")]
    public class SensorUpdateController : ApiController {

        [HttpPut]
        [Route("StallStatus")]
        public Stall PutStallStatus(Stall status) {
            Stall.UpdateStatus(status); //store update
            BathroomInfoController.bathrooms = Bathroom.LoadAll(); //reload bathroom data
            return status;
        }

        [HttpGet]
        [Route("StallStatusGet")]
        public Stall StallStatusGet(int id, bool occupied) {
            Stall status = new Stall();
            status.id = id;
            status.occupied = occupied;
            Stall.UpdateStatus(status); //store update
            BathroomInfoController.bathrooms = Bathroom.LoadAll(); //reload bathroom data
            return status;
        }
    }
}
