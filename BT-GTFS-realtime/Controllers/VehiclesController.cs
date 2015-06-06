using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BT_GTFS_realtime.Models;

namespace BT_GTFS_realtime.Controllers
{
    public class VehiclesController : ApiController
    {
        // GET api/values
        public IEnumerable<Item> Get()
        {
            return new Item[] {
                new Item {
                    Id = 123,
                    Name = "The Yellow Submarine",
                    Value = 654321,
                }
            };
            //return new string[] { "value1", "value2" };
        }
    }
}
