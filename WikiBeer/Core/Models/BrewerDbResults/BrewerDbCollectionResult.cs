using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WikiBeer.Core.Models.BrewerDbResults
{
    [DataContract]
    public class BrewerDbCollectionResult<T> : BrewerDbResult where T : class
    {
        [DataMember(Name = "data")]
        public IEnumerable<T> Objects { get; set; }
        [DataMember(Name = "currentPage")]
        public int CurrentPageNumber { get; set; }
        [DataMember(Name = "numberOfPages")]
        public int TotalNumberOfPages { get; set; }
        [DataMember(Name = "totalResults")]
        public int TotalNumberOfResults { get; set; }
    }
}