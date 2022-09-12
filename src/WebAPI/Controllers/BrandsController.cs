using Application.Features.Brands.Commands.CreateBrands;
using Application.Features.Brands.Dtos.Responses;
using Application.Features.Brands.Queries;
using Core.Application.Requests;
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

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new GetListBrandQuery { PageRequest = pageRequest };
            BrandListResponseDto listBrandResponseDto = await Mediator.Send(getListBrandQuery);
            return Ok(listBrandResponseDto);

        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] long Id)
        {
            GetByIdBrandQuery getListByIdBrandQuery = new GetByIdBrandQuery { Id = Id };
            BrandResponseDto brand  = await Mediator.Send(getListByIdBrandQuery);
            return Ok(brand);

        }
    }
}
