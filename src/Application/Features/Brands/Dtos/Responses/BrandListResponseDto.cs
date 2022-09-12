using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Dtos.Responses
{
    public class BrandListResponseDto:BasePageableModel
    {
        public IList<BrandResponseDto> Items { get; set; }
    }
}
