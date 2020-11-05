using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Books
{
    public interface IBookAppService : ICrudAppService<
        BookDto,    //used to show books
        Guid,       //Primary key of the book entity
        PagedAndSortedResultRequestDto, //used for pagin/sorting
        CreateUpdateBookDto>    //used to create/update a book
    {
        // Add the new method
        Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();
    }
}
