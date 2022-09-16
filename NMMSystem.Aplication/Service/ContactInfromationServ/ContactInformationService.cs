﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NMMSystem.Data.Domein;
using NNMSystem.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMMSystem.Aplication.Service.ContactInfromationServ
{
    public class ContactInformationService : IContactInformationService
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public ContactInformationService(IContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponce<string>> AddContactInformation(ContactInformationDto request,Supplier supplier)
        {
            var response=new ServiceResponce<string>();
            var contactInformation=_mapper.Map<ContactInformation>(request);
            contactInformation.Supplier = supplier;
            await _context.ContactInformation.AddAsync(contactInformation);
            _context.SaveChanges();
            return response;
        }

        public async Task<ServiceResponce<string>> DeleteContactInformationBySupplierId(int supplierId)
        {

            var responce = new ServiceResponce<string>();
            var getSupplierById = await _context.ContactInformation.FirstOrDefaultAsync(x => x.SupplierId == supplierId);
            if (getSupplierById == null)
            {
                responce.Success = false;               
                return responce;
            }
            _context.ContactInformation.Remove(getSupplierById);
            _context.SaveChanges();
            responce.Success = true;           
            return responce;

        }
    }
}
