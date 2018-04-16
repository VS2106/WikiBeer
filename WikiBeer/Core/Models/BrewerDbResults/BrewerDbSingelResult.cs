using System.Runtime.Serialization;

namespace WikiBeer.Core.Models.BrewerDbResults
{
    [DataContract]
    public class BrewerDbSingelResult<T> : BrewerDbResult where T : class
    {
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "data")]
        public T Instance { get; set; }
    }
}