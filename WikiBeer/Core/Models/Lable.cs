using System.Runtime.Serialization;

namespace WikiBeer.Core.Models
{
    [DataContract]
    public class Lable
    {
        [DataMember(Name = "icon")]
        public string SmallImagePath { get; set; }
        [DataMember(Name = "medium")]
        public string MediumImagePath { get; set; }
        [DataMember(Name = "large")]
        public string LargeImagePath { get; set; }
    }
}