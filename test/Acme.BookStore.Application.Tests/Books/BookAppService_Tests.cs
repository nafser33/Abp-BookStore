﻿using Acme.BookStore.Authors;
using Microsoft.EntityFrameworkCore.Internal;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace Acme.BookStore.Books
{
    public class BookAppService_Tests : BookStoreApplicationTestBase
    {
        private readonly IBookAppService _bookAppService;
        private readonly IAuthorAppService _authorAppService;

        public BookAppService_Tests()
        {
            _bookAppService = GetRequiredService<IBookAppService>();
            _authorAppService = GetRequiredService<IAuthorAppService>();
        }

        [Fact]
        public async Task Should_Get_List_of_Books()
        {
            //Act
            var result = await _bookAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
                );

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.Name == "1984" && b.AuthorName == "George Orwell"

                );
        }

        [Fact]
        public async Task Should_Not_Create_A_Book_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
                {
                    await _bookAppService.CreateAsync(
                        new CreateUpdateBookDto
                        {
                            Name = "",
                            Price = 10,
                            PublishDate = DateTime.Now,
                            Type = BookType.ScienceFiction
                        }
                    );
                }

            );

            exception.ValidationErrors.ShouldContain(err => err.MemberNames.Any(m => m == "Name"));
        }


        [Fact]
        public async Task Should_Create_A_Valid_Book()
        {
            //Act
            var result = await _bookAppService.CreateAsync(
                new CreateUpdateBookDto
                {
                    Name = "New test book 42",
                    Price = 10,
                    PublishDate = System.DateTime.Now,
                    Type = BookType.ScienceFiction
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("New test book 42");
        }

    }
}