using System.Collections.Generic;
using System.Web.Http;
using transit_realtime;

namespace BT_GTFS_realtime.Controllers
{
    public class VehiclesController : ApiController
    {
        public IEnumerable<VehicleDescriptor> Get()
        {
            return new VehicleDescriptor[] {
                new VehicleDescriptor {
                    id = "yellow",
                    label = "The Yellow Submarine",
                }
            };
        }
    }
}
