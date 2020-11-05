using System;
using System.Runtime.Serialization;
using Volo.Abp;

namespace Acme.BookStore.Authors
{
    [Serializable]
    public class AuthorAlreadyExistsException : BusinessException
    {
        public AuthorAlreadyExistsException(string name)
            :base(BookStoreDomainErrorCodes.AuthorAlreadyExists)
        {
            WithData("name", name);
        }

    }
}