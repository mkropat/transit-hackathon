var GtfsRealtimeBindings = require('gtfs-realtime-bindings');
var request = require('request');
 
var requestSettings = {
  method: 'GET',
  url: 'http://localhost:60990/api/Vehicles/',
  encoding: null,
  headers: {
    'Accept': 'application/x-protobuf'
  }
};
request(requestSettings, function (error, response, body) {
  if (!error && response.statusCode == 200) {
    var feed = GtfsRealtimeBindings.FeedMessage.decode(body);
    console.log(feed);
    //feed.entity.forEach(function(entity) {
    //  console.log(entity.vehicle);
    //  //if (entity.trip_update) {
    //  //  console.log(entity.trip_update);
    //  //}
    //});
  }
});
