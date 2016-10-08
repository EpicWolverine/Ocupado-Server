using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ocupado_WebServer.Models;

namespace Ocupado_WebServer.Controllers
{
    public class SensorUpdateController : ApiController
    {
        List<Bathroom> bathrooms = new List<Bathroom>();

        public IEnumerable<Bathroom> GetBathrooms()
        {
            bathrooms.Add(new Bathroom { occupied = true, location = new Location { floor = 1 } });
            return bathrooms;
        }
    }
}
