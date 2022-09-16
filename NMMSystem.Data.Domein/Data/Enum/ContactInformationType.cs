﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NMMSystem.Data.Domein.Data.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContactInformationType
    {
        Phone=1,
        Mobile=2,
        Email=3,
        Fax=4,
    }
}
