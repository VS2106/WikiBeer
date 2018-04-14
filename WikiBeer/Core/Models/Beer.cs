using System.Runtime.Serialization;

namespace WikiBeer.Core.Models
{
    [DataContract]
    public class Beer
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "abv")]
        public decimal AlcoholByVolume { get; set; }
        [DataMember(Name = "style")]
        public Style Style { get; set; }
        [DataMember(Name = "labels")]
        public Lable Label { get; set; }

        [DataMember(Name = "isOrganic")]
        public string Organic { private get; set; }
        public bool IsOrganic
        {
            get
            {
                switch (Organic)
                {
                    case "N": return false;
                    case "Y": return true;
                    default: return false;
                }
            }
        }
    }
}