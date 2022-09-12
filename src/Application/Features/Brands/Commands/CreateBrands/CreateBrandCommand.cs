using Application.Features.Brands.Dtos.Requests;
using Application.Features.Brands.Dtos.Responses;
using Application.Features.Brands.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrands
{
    public class CreateBrandCommand:IRequest<BrandResponseDto>
    {
        public BrandRequestDto brandRequestDto { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, BrandResponseDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;
            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<BrandResponseDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await CheckBusinessRules(request.brandRequestDto);
                Brand brand = _mapper.Map<Brand>(request.brandRequestDto);
                Brand createdBrand = await _brandRepository.AddAsync(brand);
                BrandResponseDto response = _mapper.Map<BrandResponseDto>(createdBrand);
                return response;

            }

            private async Task CheckBusinessRules(BrandRequestDto dto)
            {
                await _brandBusinessRules.BrandNameCanNotBeDuplicated(dto.Name);
            }
        }

    }
}
