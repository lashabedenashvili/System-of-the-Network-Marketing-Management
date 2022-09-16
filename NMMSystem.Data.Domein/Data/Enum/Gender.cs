using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NMMSystem.Data.Domein
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Male=1 , 
        Female=2, 
    }
}
