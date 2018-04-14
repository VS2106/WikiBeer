using System.Runtime.Serialization;

namespace WikiBeer.Core.Models
{
    [DataContract]
    public class Style
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "abvMin")]
        public decimal MinimumAlcoholByVolume { get; set; }
        [DataMember(Name = "abvMax")]
        public decimal MaximumAlcoholByVolume { get; set; }
    }
}