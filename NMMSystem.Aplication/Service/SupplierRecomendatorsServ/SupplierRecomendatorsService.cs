using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NMMSystem.Data.Domein;
using NMMSystem.Data.Domein.Data;
using NNMSystem.Infrastructure.Dto.RegistrationSupplierDto;
using System;
using System.Collections;
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
            var limitRecomender = await RecommenderLimitation(request.Recomendator.Value);

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
            int level = 5;
           
            var response = new ServiceResponce<string>();
            var supplierLimit = await _context.SupplierRecomendators
                .CountAsync(x => x.RecommenderSupplierId == supplierId);

            if (supplierLimit > 3)
            {
                response.Success = false;
                response.Message = "The number of recommendations has been exhausted";
                return response;
            }
            
            var hierarchy = await HierarchyControl(supplierId, level);
            int countHierarchy = 0;

            for (int i = 0; i < hierarchy.Data.Count; i++)
            {
                countHierarchy++;


                if (countHierarchy > 121)
                {
                    response.Success=false;
                    response.Message = "The number of recommendations is full (121 person)";
                    return response;
                }

            }
            response.Success = true;
            return response;

        }

        public async Task<ServiceResponce<List<int>>> HierarchyControl(int RecomenderSupplierId,int level = 5)
        {

            var response = new ServiceResponce<List<int>>();
            List<int> allHirarcky = new List<int>();            
            var supplierFirsRank = await _context.SupplierRecomendators
                .Where(x => x.RecommenderSupplierId.Equals(RecomenderSupplierId))
                .Select(x => x.RecommendedSupplierId).ToListAsync();

            var CheckUnderRanks = supplierFirsRank.Count > 0;
            allHirarcky.AddRange(supplierFirsRank);

            while (CheckUnderRanks)
            {
                int levelCheck = 1;
                for (int i = 0; i < allHirarcky.Count ; i++)
                {
                    if (levelCheck == level)
                        break;

                    var nextRankRecomender = allHirarcky[i];

                    var supplierNextRank = await _context.SupplierRecomendators
                    .Where(x => x.RecommenderSupplierId.Equals(nextRankRecomender))
                    .Select(x => x.RecommendedSupplierId).ToListAsync();

                    if (supplierNextRank.Count > 0)
                    {
                        levelCheck++;
                        allHirarcky.AddRange(supplierNextRank);
                    }                        
                   
                }

                CheckUnderRanks = false;
            }
            response.Data = allHirarcky;
            response.Success = true;



            return response;
        }

        
    }
}
