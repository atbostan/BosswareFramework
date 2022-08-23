using Application.Features.Brands.Commands.CreateBrands;
using Application.Features.Brands.Dtos.Brand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            BrandResponseDto  result = await Mediator.Send(createBrandCommand);
            return Created("", result);

        }
    }
}
