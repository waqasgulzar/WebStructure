using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Web.Common.Enumerations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MessageType : int
    {
        Fatal = 1,
        Error = 2,
        Warning = 3,
        Info = 4,
    }
}
