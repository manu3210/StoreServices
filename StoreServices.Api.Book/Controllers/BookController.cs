using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreServices.Api.Book.Application;

namespace StoreServices.Api.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBook.CreateBookRequest data)
        {
            var book = await _mediator.Send(data);

            if (book != null)
                return Ok(book);

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllBooks()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var book = await _mediator.Send(new GetBookById.Query(id));
            
            if(book != null)
                return Ok(book);

            return NotFound();
        }
    }
}
