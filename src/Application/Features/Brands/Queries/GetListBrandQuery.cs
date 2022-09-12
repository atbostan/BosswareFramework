using Application.Features.Brands.Dtos.Responses;
using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging.abstracts;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries
{
    public class GetListBrandQuery:IRequest<BrandListResponseDto>
    {
        public PageRequest PageRequest;
       
        public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, BrandListResponseDto>
        {

            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }
            public async Task<BrandListResponseDto> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Brand> brandList = await _brandRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
                BrandListResponseDto result = _mapper.Map<BrandListResponseDto>(brandList);
                return result;
            }
        }
    }
}
