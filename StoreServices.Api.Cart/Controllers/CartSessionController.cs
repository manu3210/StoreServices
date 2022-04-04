using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreServices.Api.Cart.Application;

namespace StoreServices.Api.Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartSessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartSessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCart.CreateCartRequest data)
        {
            var cart = _mediator.Send(data);
            if (cart != null)
                return Ok();
            return BadRequest();
        }
    }
}
