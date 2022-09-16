using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NMMSystem.Data.Domein.Data.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AddressType
    {
        ActualAddress=1,
        RegistrationAddress=2,
    }
}
