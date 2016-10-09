using Ocupado_WebServer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ocupado_WebServer.Controllers {
    public class SensorUpdateController : ApiController {
        public Stall PutStallStatus(Stall status) {
            Stall.UpdateStatus(status); //store update
            BathroomInfoController.bathrooms = Bathroom.LoadAll(); //reload bathroom data
            return status;
        }
    }
}
