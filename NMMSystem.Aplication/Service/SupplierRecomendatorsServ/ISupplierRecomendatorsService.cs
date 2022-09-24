using Microsoft.EntityFrameworkCore.ChangeTracking;
using NMMSystem.Data.Domein;
using NNMSystem.Infrastructure.Dto.RegistrationSupplierDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Aplication.Service.SupplierRecomendatorsServ
{
    public interface ISupplierRecomendatorsService
    {

        Task<ServiceResponce<List<int>>> HierarchyControl(int RecomenderSupplierId,int level = 5);
        Task<ServiceResponce<string>> AddSupplierRecomendators(int? recomendator, Supplier supplier);
    }
}
