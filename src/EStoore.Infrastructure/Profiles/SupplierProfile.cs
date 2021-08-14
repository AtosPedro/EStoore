using AutoMapper;
using EStoore.Domain.DTOs.Supplier;
using EStoore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoore.Infrastructure.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, ReadSupplierDto>().ReverseMap();
            CreateMap<UpdateSupplierDto, Supplier>().ReverseMap();
            CreateMap<CreateSupplierDto, Supplier>().ReverseMap();
            CreateMap<SupplierMaterialDto, Supplier>().ReverseMap();
        }
    }
}
