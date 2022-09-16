﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NMMSystem.Aplication.Service.AddressInfoServ;
using NMMSystem.Aplication.Service.ContactInfromationServ;
using NMMSystem.Aplication.Service.PrivateInfromationServ;
using NMMSystem.Data.Domein;
using NNMSystem.Infrastructure.Dto;
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

        public SupplierService(IContext context, IMapper mapper, IContactInformationService contactInformationService
            , IAddressInfoService addressInfoService, IPrivateInfromationService privateInfromationService)
        {
            _context = context;
            _mapper = mapper;
            _contactInformationService = contactInformationService;
            _addressInfoService = addressInfoService;
            _privateInfromationService = privateInfromationService;
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
            await AddSupplier(request);
            // ეს შვება ყველაფერს, ეს გაეშვება თუარა საფლაიერის ბაზაში მეორეჯერ ვარდება მონაცემი
            await _privateInfromationService.AddPrivateInformation(request.PrivateInformation, _supplier);
            await _addressInfoService.AddAddressInfo(request.AddressInfo, _supplier);
            await _contactInformationService.AddContactInformation(request.ContactInformation, _supplier);
            return response;

        }

        private async Task<ServiceResponce<string>> AddSupplier(SupplierRegistrationDto request)
        {
            var responce = new ServiceResponce<string>();
            var addsupplier = _mapper.Map<Supplier>(request.Supplier);
            await _context.Supplier.AddAsync(addsupplier);
            _context.SaveChanges();
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
            _context.SaveChanges();
            responce.Success = true;
            responce.Message = "Supplier is already deleted";
            return responce;
        }

    }
}
