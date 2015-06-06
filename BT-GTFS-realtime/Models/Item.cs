using System.Runtime.Serialization;

namespace BT_GTFS_realtime.Models
{
    [DataContract]
    public class Item
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
        [DataMember(Order = 3)]
        public long Value { get; set; }
    }
}