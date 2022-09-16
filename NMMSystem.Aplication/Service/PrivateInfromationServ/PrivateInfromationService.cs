using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NMMSystem.Data.Domein;
using NNMSystem.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Aplication.Service.PrivateInfromationServ
{
    public class PrivateInfromationService : IPrivateInfromationService
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public PrivateInfromationService(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponce<string>> AddPrivateInformation(PrivateInformationDto request, Supplier supplier)
        {
            var responce = new ServiceResponce<string>();
            var privateInfo = _mapper.Map<PrivateInformation>(request);
            privateInfo.Supplier = supplier;
            await _context.PrivateInformation.AddAsync(privateInfo);
            _context.SaveChanges();
            return responce;
        }

        public async Task<ServiceResponce<string>> DeletePrivateInformationBySupplierId(int supplierId)
        {
            var responce = new ServiceResponce<string>();
            var getSupplierById = await _context.PrivateInformation.FirstOrDefaultAsync(x => x.SupplierId == supplierId);
            if (getSupplierById == null)
            {
                responce.Success = false;
                return responce;
            }
            _context.PrivateInformation.Remove(getSupplierById);
            _context.SaveChanges();
            responce.Success = true;
            return responce;
        }
    }
}
