﻿using NMMSystem.Data.Domein.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.Dto
{
    public class PrivateInformationDto
    {
        public DocumentType DocumenType { get; set; }

     
        public string DocumentNumber { get; set; }

       
        public string SerialNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateIssue { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateExpiry { get; set; }
       
        public string PrivateNumber { get; set; }
   
        public string IssuingAutority { get; set; }


    }
}
