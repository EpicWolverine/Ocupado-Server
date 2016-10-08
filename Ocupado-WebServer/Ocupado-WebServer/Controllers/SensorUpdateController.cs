using Ocupado_WebServer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ocupado_WebServer.Controllers
{
    public class SensorUpdateController : ApiController
    {
        List<Bathroom> bathrooms = new List<Bathroom>();

        public IEnumerable<Bathroom> GetBathrooms()
        {
            
            return bathrooms;
        }

        public Stall PutStallStatus(Stall status)
        {

            return status;
        }
    }
}
