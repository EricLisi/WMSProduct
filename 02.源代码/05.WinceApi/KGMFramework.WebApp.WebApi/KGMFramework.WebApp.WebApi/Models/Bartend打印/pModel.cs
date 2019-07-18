using System.Runtime.Serialization;

namespace KGMFramework.WebApp.WebApi.Models
{
    [DataContract]
    public class pModel
    {
        [DataMember]
        public string jsonstr { get; set; }
    }
}
