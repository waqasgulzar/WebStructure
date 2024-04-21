using System.Text.Json.Serialization;
using Web.Common.Enumerations;

namespace Web.Common.Models
{
    public class Message
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MessageType MessageType { get; set; }
        public string MessageText { get; set; }
    }
}
