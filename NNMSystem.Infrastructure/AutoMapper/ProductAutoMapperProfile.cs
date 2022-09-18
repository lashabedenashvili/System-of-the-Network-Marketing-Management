using AutoMapper;
using NMMSystem.Data.Domein.Data;
using NNMSystem.Infrastructure.Dto.AddProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNMSystem.Infrastructure.AutoMapper
{
    public class ProductAutoMapperProfile:Profile
    {
        public ProductAutoMapperProfile()
        {
            CreateMap<AddProductDto, Product>();
        }
    }
}
