using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NMMSystem.Data.Domein;
using NNMSystem.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Aplication.Service.AddressInfoServ
{

    public class AddressInfoService : IAddressInfoService
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public AddressInfoService(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponce<string>> AddAddressInfo(AddressInfoDto request, Supplier supplier)
        {
            var responce = new ServiceResponce<string>();
            var addressInfo = _mapper.Map<AddressInfo>(request);
            addressInfo.Supplier = supplier;
            await _context.AddressInfo.AddAsync(addressInfo);
            _context.SaveChanges();
            return responce;


        }

        public async Task<ServiceResponce<string>> DeleteAddressBySupplierId(int supplierId)
        {
            
                var responce = new ServiceResponce<string>();
                var getSupplierById = await _context.AddressInfo.FirstOrDefaultAsync(x => x.SupplierId == supplierId);
                if (getSupplierById == null)
                {
                    responce.Success = false;
                    responce.Message = "Supplier does not exist";
                    return responce;
                }
                _context.AddressInfo.Remove(getSupplierById);
                _context.SaveChanges();
                responce.Success = true;
                responce.Message = "Supplier is already deleted";
                return responce;
            
        }
    }
}
