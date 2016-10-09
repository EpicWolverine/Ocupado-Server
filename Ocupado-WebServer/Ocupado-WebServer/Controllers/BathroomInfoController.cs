using Ocupado_WebServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ocupado_WebServer.Controllers {
    public class BathroomInfoController : ApiController {
        public static List<Bathroom> bathrooms = Bathroom.LoadAll();

        public IEnumerable<Bathroom> GetBathroom() {
            return bathrooms;
        }

        public Bathroom GetBathroom(int id) {
            return bathrooms.FirstOrDefault(x => x.id == id);
        }
    }
}
