using Application.Features.Brands.Commands.CreateBrands;
using Application.Features.Brands.Dtos.Brand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand,BrandRequestDto>().ReverseMap();
            CreateMap<Brand,BrandResponseDto>().ReverseMap();
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        }
    }
}
