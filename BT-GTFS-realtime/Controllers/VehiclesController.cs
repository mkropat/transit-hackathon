using System.Collections.Generic;
using System.Web.Http;
using transit_realtime;

namespace BT_GTFS_realtime.Controllers
{
    public class VehiclesController : ApiController
    {
        public FeedMessage Get()
        {
            var client = new BT4U.BT4U_WebServiceSoapClient("BT4U_WebServiceSoap12");
            var response = client.GetCurrentBusInfo();


            var message = new FeedMessage();
            message.header = new FeedHeader();
            message.header.gtfs_realtime_version = "1.0";
            message.header.incrementality = FeedHeader.Incrementality.FULL_DATASET;

            var update = new FeedEntity();
            message.entity.Add(update);

            update.id = "1922";

            var vehicle = update.vehicle = new VehiclePosition();

            var descriptor = vehicle.vehicle = new VehicleDescriptor();
            descriptor.label = response.InnerXml;

            var position = vehicle.position = new Position();
            position.latitude = 37.24212F;
            position.longitude = -80.43342F;

            return message;
        }
    }
}
