using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NMMSystem.Data.Domein;
using NMMSystem.Data.Domein.Data;
using NNMSystem.Infrastructure.Dto.RegistrationSupplierDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Aplication.Service.SupplierRecomendatorsServ
{


    public class SupplierRecomendatorsService : ISupplierRecomendatorsService
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public SupplierRecomendatorsService(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponce<string>> AddSupplierRecomendators(SupplierRegistrationDto request)
        {
            var response = new ServiceResponce<string>();
            var limitRecomender=await RecommenderLimitation(request.Recomendator.Value);
          
            var _supplier = _mapper.Map<Supplier>(request.Supplier);
            if (!limitRecomender.Success)
            {
                response.Success = false;
                response.Message = limitRecomender.Message;
                return response;

            }

            await _context.Supplier.AddAsync(_supplier);
            if (request.Recomendator.HasValue)
            {
                var rec = await _context.Supplier
                                .FirstOrDefaultAsync(e => e.Id == request.Recomendator.Value);

                if (rec != null)
                {
                    var recom = new SupplierRecomendators()
                    {
                        RecommenderSupplierId = request.Recomendator.Value,
                        RecommendedSupplier = _supplier
                    };

                    await _context.SupplierRecomendators.AddAsync(recom);
                }

            }
            return response;
        }
        public async Task<ServiceResponce<string>> RecommenderLimitation(int supplierId)
        {
            var response = new ServiceResponce<string>();
            var supplierLimit = await _context.SupplierRecomendators
                .CountAsync(x => x.RecommenderSupplierId == supplierId);

            if (supplierLimit>3)
            {
                response.Success = false;
                response.Message = "The number of recommendations has been exhausted";
                return response;
            }
            response.Success = true;
            return response;

        }
    }
}
