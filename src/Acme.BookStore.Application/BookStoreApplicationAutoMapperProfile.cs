using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using AutoMapper;
using System.Text;


namespace Acme.BookStore
{
    public class BookStoreApplicationAutoMapperProfile : Profile
    {
        public BookStoreApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<Book, BookDto>(); // Book entity is the source, UI is the destination
            CreateMap<CreateUpdateBookDto, Book>(); //UI is the source, Book entity is the destination

            CreateMap<Author, AuthorDto>();

            CreateMap<Author, AuthorLookupDto>();

        }
    }
}
