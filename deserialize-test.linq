<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.Install.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Messaging.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <NuGetReference>GtfsRealtimeBindings</NuGetReference>
  <NuGetReference>protobuf-net</NuGetReference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>ProtoBuf</Namespace>
</Query>

using (var client = new HttpClient())
{
	var message = new HttpRequestMessage(HttpMethod.Get, "http://localhost:60990/api/Vehicles/");
	message.Headers.Add("Accept", "application/x-protobuf");
	var response = await client.SendAsync(message);
	
	var m = Serializer.Deserialize<transit_realtime.FeedMessage>(await response.Content.ReadAsStreamAsync());
	m.Dump();
}
