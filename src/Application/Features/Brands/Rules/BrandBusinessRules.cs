using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging.abstracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;

        }

        public async Task BrandNameCanNotBeDuplicated(string name)
        {
            IPaginate<Brand> result = await _brandRepository.GetListAsync(x => x.Name == name);
            if (result.Items.Any()) throw new BusinessException("Brand name is already exist");
        }


        public async Task BrandIdIsNotExist(long id)
        {
            Brand result = await _brandRepository.GetAsync(x => x.Id == id);
            if (result == null) throw new BusinessException("There is no brand with given id");
        }
    }
}
