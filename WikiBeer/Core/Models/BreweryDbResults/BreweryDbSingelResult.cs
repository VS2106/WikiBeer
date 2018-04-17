using System.Runtime.Serialization;

namespace WikiBeer.Core.Models.BreweryDbResults
{
    [DataContract]
    public class BreweryDbSingelResult<T> : BreweryDbResult where T : class
    {
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "data")]
        public T Instance { get; set; }
    }
}