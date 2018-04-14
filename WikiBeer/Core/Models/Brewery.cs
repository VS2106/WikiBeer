using System.Runtime.Serialization;

namespace WikiBeer.Core.Models
{
    [DataContract]
    public class Brewery
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "images")]
        public Lable Label { get; set; }
    }
}