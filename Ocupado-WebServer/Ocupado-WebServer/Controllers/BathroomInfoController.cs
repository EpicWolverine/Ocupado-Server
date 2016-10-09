using Ocupado_WebServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ocupado_WebServer.Controllers {
    [RoutePrefix("api/BathroomInfo")]
    public class BathroomInfoController : ApiController {
        public static List<Bathroom> bathrooms = Bathroom.LoadAll();

        [HttpGet]
        [Route("Bathrooms")]
        public IEnumerable<Bathroom> GetAllBathrooms() {
            //bathrooms = Bathroom.LoadAll();
            return bathrooms;
        }

        [HttpGet]
        [Route("Bathrooms")]
        public Bathroom GetBathroomsById(int id) {
            return bathrooms.FirstOrDefault(x => x.id == id);
        }
    }
}
