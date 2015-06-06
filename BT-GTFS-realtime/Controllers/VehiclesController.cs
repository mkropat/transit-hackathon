using System.Collections.Generic;
using System.Web.Http;
using System.Xml.Linq;
using transit_realtime;

namespace BT_GTFS_realtime.Controllers
{
    public class VehiclesController : ApiController
    {
        public FeedMessage Get()
        {
            var client = new BT4U.BT4U_WebServiceSoapClient("BT4U_WebServiceSoap12");
            var response = client.GetCurrentBusInfo();
            var doc = XElement.Parse(response.OuterXml);

            var message = new FeedMessage();
            message.header = new FeedHeader();
            message.header.gtfs_realtime_version = "1.0";
            message.header.incrementality = FeedHeader.Incrementality.FULL_DATASET;

            foreach (var vehicleNode in doc.Descendants("LatestInfoTable")) {

                if (vehicleNode.Element("Latitude").Value == "0")
                    continue;

                var update = new FeedEntity();

                message.entity.Add(update);

                update.id = vehicleNode.Element("AgencyVehicleName").Value;

                var vehicle = update.vehicle = new VehiclePosition();

                var descriptor = vehicle.vehicle = new VehicleDescriptor();

                var position = vehicle.position = new Position();

                position.latitude = float.Parse(vehicleNode.Element("Latitude").Value);
                position.longitude = float.Parse(vehicleNode.Element("Longitude").Value);
            }

            return message;
        }
    }
}
