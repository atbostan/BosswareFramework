using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class BrandRepository: EfRepositoryBase<Brand,AppDbContext>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) :base(context)
        {

        }
    }
}
