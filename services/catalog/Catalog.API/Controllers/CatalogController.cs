using Catalog.Application.Commands.Products;
using Catalog.Application.Queries.BrandQueries;
using Catalog.Application.Queries.ProductQueries;
using Catalog.Application.Queries.TypesQueries;
using Catalog.Application.Responses;
using Catalog.Core.Specs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace Catalog.API.Controllers
{
 
    public class CatalogController : BaseApiController
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[action]/{id}",Name = "GetProductById")]
        [ProducesResponseType(typeof(IList<ProductResponseDto>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]

        public async Task<ActionResult<ProductResponseDto>> GetProductById(string id)
        {
            var query = new GetproductByNameQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);

        }
        [HttpGet]
        [Route("[action]/{product-name}", Name = "GetProductByProductName")]
        [ProducesResponseType(typeof(IList<ProductResponseDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponseDto>> GetProductByProductName(string productName)
        {
            var query = new GetProductByNameQuery(productName);
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpGet]
        [Route("GetAllProduct")]
        [ProducesResponseType(typeof(IList<ProductResponseDto>), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<ProductResponseDto>> GetAllProduct([FromQuery] CatalogSpecParam specParam)
        {
            var query = new GetAllProductQuery(specParam);
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpGet]
        [Route("GetAllBrands")]
        [ProducesResponseType(typeof(IList<BrandResponseDto>), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<BrandResponseDto>> GetAllBrands()
        {
            var query = new GetAllBrandQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

        }
        [HttpGet]
        [Route("GetAllTypes")]
        [ProducesResponseType(typeof(IList<TypeResPonseDto>), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<ProductResponseDto>> GetAllTypes()
        {
            var query = new GetAllTypesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpPost]
        [Route("CreateProduct")]
        [ProducesResponseType(typeof(ProductResponseDto), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<ProductResponseDto>> CreateProduct([FromBody] CreateProductCommand productCommand)
        {
            var result = await _mediator.Send<ProductResponseDto>(productCommand);
            return Ok(result);

        }


        [HttpPut]
        [Route("UpdateProduct")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<ProductResponseDto>> UpdateProduct([FromBody] UpdateProductCommand productCommand)
        {
            var result = await _mediator.Send<bool>(productCommand);
            return Ok(result);

        }
        [HttpDelete]
        [Route("{id}" ,Name ="DeleteProduct")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<ProductResponseDto>> DeleteProduct(string id)
        {
            var command = new DeleteProductCommand(id);
            var result = await _mediator.Send<bool>(command);
            return Ok(result);

        }


    }
}
