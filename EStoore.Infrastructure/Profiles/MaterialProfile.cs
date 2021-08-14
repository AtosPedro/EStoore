using AutoMapper;
using EStoore.Domain.DTOs.Material;
using EStoore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoore.Infrastructure.Profiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, ReadMaterialDto>().ReverseMap();
            CreateMap<UpdateMaterialDto, Material>().ReverseMap();
            CreateMap<CreateMaterialDto, Material>().ReverseMap();
            CreateMap<MaterialSupplierDto, Material>().ReverseMap();
        }
    }
}
