using AutoMapper;
using NMMSystem.Data.Domein;
using NMMSystem.Data.Domein.Data;
using NNMSystem.Infrastructure.Dto.AddProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Aplication.Service.ProductServ
{
    public class ProductService : IProductService
    {
        private readonly IContext _contex;
        private readonly IMapper _mapper;

        public ProductService(IContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }
        public async Task<ServiceResponce<string>> AddProducts(AddProductDto request)
        {
            var responce=new ServiceResponce<string>();
            var product=_mapper.Map<Product>(request);
            _contex.Product.Add(product);
            await _contex.SaveChangesAsync();
            responce.Success = true;
            return responce;
            
        }
    }
}
