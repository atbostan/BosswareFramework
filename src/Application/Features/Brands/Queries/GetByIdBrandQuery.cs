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

namespace Application.Features.Brands.Queries
{
    public class GetByIdBrandQuery : IRequest<BrandResponseDto>
    {
        public long Id { get; set; }

        public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandResponseDto>
        {

            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public GetByIdBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;

            }

            public async Task<BrandResponseDto> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetAsync(b => b.Id == request.Id);
                 _brandBusinessRules.BrandIdIsNotExist(brand.Id);
                BrandResponseDto result = _mapper.Map<BrandResponseDto>(brand);
                return result;
            }
        }
    }
}
