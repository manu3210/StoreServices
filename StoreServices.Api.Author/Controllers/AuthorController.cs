using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreServices.Api.Author.Application;
using StoreServices.Api.Author.Model;

namespace StoreServices.Api.Author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create (CreateAuthor.CreateAuthorRequest data)
        {
            var author = await _mediator.Send(data);

            if (author != null) 
                return Ok(author);

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            return Ok(await _mediator.Send(new GetAllAuthor()));
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetAuthor(string id)
        {
            var author = await _mediator.Send(new GetAuthorById.Query(id));
            if (author != null)
                return Ok(author);

            return NotFound();
        }
    }
}
