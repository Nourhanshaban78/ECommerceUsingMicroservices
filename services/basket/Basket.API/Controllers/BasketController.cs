using Basket.Application.Commands;
using Basket.Application.Queries;
using Basket.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseApiController

    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{action}/{username}",Name ="GetBasketByName")]
        [ProducesResponseType(typeof(ShoppingCartResponse),200)]
        public async Task<ActionResult<ShoppingCartResponse>> GetBasket(string username)
        {
            var shop = new GetBasketByNameQuery(username);
            var basket = await _mediator.Send(shop);
            return Ok(basket);
        }

        [HttpPost("UpdateBasket")]
        [ProducesResponseType(typeof(ShoppingCartResponse), 200)]

        public async Task<ActionResult<ShoppingCartResponse>> UpdateBasket([FromBody] UpdateShoppingCartCommand command)
        {
            var updateBasket = await _mediator.Send(command);
            return Ok(updateBasket);

        }

        [HttpDelete]
        [Route("{action}/{username}", Name = "DeleteBasket")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartResponse>> DeleteBasket(string username)
        {
            var shop = new DeleteShoppingCartCommand(username);
            var basket = await _mediator.Send(shop);
            return Ok(basket);
        }


    }
}
