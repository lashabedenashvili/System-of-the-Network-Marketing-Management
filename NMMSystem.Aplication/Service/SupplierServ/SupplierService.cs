using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NMMSystem.Aplication.Service.AddressInfoServ;
using NMMSystem.Aplication.Service.ContactInfromationServ;
using NMMSystem.Aplication.Service.PrivateInfromationServ;
using NMMSystem.Aplication.Service.SupplierRecomendatorsServ;
using NMMSystem.Data.Domein;
using NMMSystem.Data.Domein.Data;
using NNMSystem.Infrastructure.Dto;
using NNMSystem.Infrastructure.Dto.GetAllSupplier;
using NNMSystem.Infrastructure.Dto.RegistrationSupplierDto;
using NNMSystem.Infrastructure.Dto.UpdateSupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Aplication.Service.SupplierServ
{
    public class SupplierService : ISupplierService
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        private readonly IContactInformationService _contactInformationService;
        private readonly IAddressInfoService _addressInfoService;
        private readonly IPrivateInfromationService _privateInfromationService;
        private readonly ISupplierRecomendatorsService _supplierRecomendatorsService;

        public SupplierService(IContext context, IMapper mapper, IContactInformationService contactInformationService
            , IAddressInfoService addressInfoService, IPrivateInfromationService privateInfromationService,
            ISupplierRecomendatorsService SupplierRecomendatorsService)
        {
            _context = context;
            _mapper = mapper;
            _contactInformationService = contactInformationService;
            _addressInfoService = addressInfoService;
            _privateInfromationService = privateInfromationService;
            _supplierRecomendatorsService = SupplierRecomendatorsService;
        }

        public async Task<ServiceResponce<string>> DeleteSupplier(int supplierId)
        {
            var response = new ServiceResponce<string>();
            var deleteSipplier = await DeleteSupplierById(supplierId);
            if (deleteSipplier.Success == false)
            {
                response.Message = deleteSipplier.Message;
                response.Success = false;
                return response;
            }
            else
            {
                await _contactInformationService.DeleteContactInformationBySupplierId(supplierId);
                await _addressInfoService.DeleteAddressBySupplierId(supplierId);
                await _privateInfromationService.DeletePrivateInformationBySupplierId(supplierId);
                response.Success = true;
            }
            return response;
        }
        public async Task<ServiceResponce<string>> SupplierRegistration(SupplierRegistrationDto request)
        {
            var response = new ServiceResponce<string>();
            var _supplier = _mapper.Map<Supplier>(request.Supplier);
            var supplier=await _context.Supplier.AddAsync(_supplier);
            
            await _privateInfromationService.AddPrivateInformation(request.PrivateInformation, supplier.Entity);
            await _addressInfoService.AddAddressInfo(request.AddressInfo, supplier.Entity);
            await _contactInformationService.AddContactInformation(request.ContactInformation, supplier.Entity);


            var supplierLimit = await _supplierRecomendatorsService.AddSupplierRecomendators(request.Recomendator,supplier.Entity);
            if (!supplierLimit.Success)
            {
                response.Success = false;
                response.Message = supplierLimit.Message;
                
            }

            await _context.SaveChangesAsync();



            return response;

        }
        public async Task<ServiceResponce<string>> UpdateSupplier(UpdateSupplierDto request)
        {
            var response = new ServiceResponce<string>();
            var supplierExist = await SupplierExist(request);
            if (!supplierExist.Success)
            {
                response.Success = false;
                response.Message = supplierExist.Message;
                return response;
            }
            else
            {
                await UpdateSupplierById(request);
                await _privateInfromationService.UpdatePrivateInformation(request);
                await _contactInformationService.UpdateContactInformation(request);
                await _addressInfoService.UpdateAddressInfo(request);
                response.Success = true;
            }
            return response;
        }
        private async Task<ServiceResponce<int>> UpdateSupplierById(UpdateSupplierDto request)
        {
            var response = new ServiceResponce<int>();
            var supplierInfoFromDb = _context.Supplier
                .FirstOrDefaultAsync(x => x.Id == request.SupplieDto.SupplierId);
            var updateSupplier = _mapper.Map<SupplieDto, Supplier>
                (request.SupplieDto, await supplierInfoFromDb);
            _context.Supplier.Update(updateSupplier);
            await _context.SaveChangesAsync();
            return response;

        }
        private async Task<ServiceResponce<string>> AddSupplier(SupplierRegistrationDto request)
        {
            var responce = new ServiceResponce<string>();
            var addsupplier = _mapper.Map<Supplier>(request.Supplier);
            await _context.Supplier.AddAsync(addsupplier);
            return responce;
        }
        private async Task<ServiceResponce<bool>> DeleteSupplierById(int supplierId)
        {
            var responce = new ServiceResponce<bool>();
            var getSupplierById = await _context.Supplier.FirstOrDefaultAsync(x => x.Id == supplierId);
            if (getSupplierById == null)
            {
                responce.Success = false;
                responce.Message = "Supplier does not exist";
                return responce;
            }
            _context.Supplier.Remove(getSupplierById);
            await _context.SaveChangesAsync();
            responce.Success = true;
            responce.Message = "Supplier is already deleted";
            return responce;
        }
        private async Task<ServiceResponce<bool>> SupplierExist(UpdateSupplierDto request)
        {
            var responce = new ServiceResponce<bool>();
            var supplier = await _context.Supplier.FirstOrDefaultAsync(x => x.Id == request.SupplieDto.SupplierId);
            if (supplier == null)
            {
                responce.Success = false;
                responce.Message = "Supplier does not exist.";
                return responce;
            }
            else
            {
                responce.Success = true;
            }
            return responce;
        }
        public async Task<ServiceResponce<List<GetAllSuplierDto>>> GetSupplier()
        {
            var response=new ServiceResponce<List<GetAllSuplierDto>>();

            var suppliers= await _context.Supplier.Include(e => e.ContactInfromations)
                                            .Include(e => e.PrivateInfromations)
                                            .Include(e => e.AddressInfromations)
                                            .ToListAsync();

            response.Data = _mapper.Map<List<GetAllSuplierDto>>(suppliers);


            return response;
        }
        
    }
}
