using System.Runtime.Serialization;

namespace WikiBeer.Core.Models.BreweryDbResults
{
    [DataContract]
    public class BreweryDbResult
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }
    }
}