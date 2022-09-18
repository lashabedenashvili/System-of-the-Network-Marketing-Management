using NNMSystem.Infrastructure.Dto.AddProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Aplication.Service.ProductServ
{
    public interface IProductService
    {
        Task<ServiceResponce<string>> AddProducts(AddProductDto request);
    }
}
