using AutoMapper;
using NMMSystem.Data.Domein.Data;
using NNMSystem.Infrastructure.Dto.AddProduct;
using NNMSystem.Infrastructure.Dto.SupplierSale;
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
           
            CreateMap<SupplierSaleDto, SupplierSale>();
            CreateMap<Product, AddProductDto>();

            CreateMap<SupplierSale, GetSupplierSalebysupplierDto>()
               .ForMember(e => e.ProductDto, opt => opt.MapFrom(s => s.Product));

            CreateMap<AddProductDto, Product>();
            CreateMap<Product, AddProductDto>();
            CreateMap<SupplierBonusSpecificTime, GetSypplierBonusInformationDto>()
                .ForMember(e => e.Surname, x => x.MapFrom(s => s.Supplier.SurName))
                .ForMember(e => e.Name, x => x.MapFrom(s => s.Supplier.Name));


        }
    }
}
