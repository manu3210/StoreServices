using FluentValidation;
using MediatR;
using StoreServices.Api.Author.Model;
using StoreServices.Api.Author.Persistance;

namespace StoreServices.Api.Author.Application
{
    public class CreateAuthor
    {
        public record CreateAuthorRequest(BookAuthor author) : IRequest<BookAuthor>;
        public class Handler : IRequestHandler<CreateAuthorRequest, BookAuthor>
        {
            private readonly AuthorContext _context;

            public Handler(AuthorContext context)
            {
                _context = context;
            }
            public async Task<BookAuthor> Handle(CreateAuthorRequest request, CancellationToken cancellationToken)
            {
                var author = new BookAuthor
                {
                    Name = request.author.Name,
                    LastName = request.author.LastName,
                    DateOfBirth = request.author.DateOfBirth,
                    BookAuthorGuid = Convert.ToString(Guid.NewGuid())
                };

                _context.BookAuthors.Add(author);
                await _context.SaveChangesAsync();

                return author;
            }

        }

        public class AuthorValidations : AbstractValidator<CreateAuthorRequest>
        {
            public AuthorValidations()
            {
                RuleFor(x => x.author.Name).NotEmpty();
                RuleFor(x => x.author.LastName).NotEmpty();
            }
        }
    }
}
