using FluentValidation;
using MediatR;
using StoreServices.Api.Book.Model;
using StoreServices.Api.Book.Persistance;
using StoreServices.RabbitMQ.Bus.BusRabbit;
using StoreServices.RabbitMQ.Bus.EventQueue;

namespace StoreServices.Api.Book.Application
{
    public class CreateBook
    {
        public record CreateBookRequest(BookMaterial book) : IRequest<BookMaterial>;
        public class Handler : IRequestHandler<CreateBookRequest, BookMaterial>
        {
            private readonly BookContext _context;
            private readonly IRabbitEventBus _eventBus;

            public Handler(BookContext context, IRabbitEventBus eventBus)
            {
                _context = context;
                _eventBus = eventBus;
            }
            public async Task<BookMaterial> Handle(CreateBookRequest request, CancellationToken cancellationToken)
            {

                var book = new BookMaterial
                {
                    Tittle = request.book.Tittle,
                    PublicationDate = request.book.PublicationDate,
                    BookAuthor = request.book.BookAuthor,
                };

                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                _eventBus.Publish(new EmailEventQueue("manu_1019@hotmail.com", book.Tittle, "This is an example!!"));

                return book;
            }

        }

        public class BookValidations : AbstractValidator<CreateBookRequest>
        {
            public BookValidations()
            {
                RuleFor(x => x.book.Tittle).NotEmpty();
                RuleFor(x => x.book.PublicationDate).NotEmpty();
                RuleFor(x => x.book.BookAuthor).NotEmpty();
            }
        }

    }
}
