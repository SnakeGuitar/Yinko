using Microsoft.AspNetCore.Mvc;
using Yinko.Application.Books.Commands.CreateBook;
using Yinko.Application.Books.Commands.DeleteBook;
using Yinko.Application.Books.Commands.UpdateBook;
using Yinko.Application.Books.Queries.GetBook;
using Yinko.Application.Common.Models;

namespace Yinko.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            return await Mediator.Send(new GetBookQuery(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateBook(CreateBookCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID from URL doesn't match body.");
            }
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await Mediator.Send(new DeleteBookCommand(id));
            return NoContent();
        }
    }
}
