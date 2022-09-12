using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Dtos.Responses
{
    public class BrandResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? CreationDate { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? ModificationTime { get; set; }
        public long? ModificatorUserId { get; set; }


    }
}
