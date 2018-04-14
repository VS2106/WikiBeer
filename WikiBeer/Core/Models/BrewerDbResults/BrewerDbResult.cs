using System.Runtime.Serialization;

namespace WikiBeer.Core.Models.BrewerDbResults
{
    [DataContract]
    public class BrewerDbResult
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }
    }
}