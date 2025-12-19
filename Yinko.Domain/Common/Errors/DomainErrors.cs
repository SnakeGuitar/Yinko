using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yinko.Domain.Common.Errors
{
    public static class DomainErrors
    {
        public static class Book
        {
            public const string TitleRequired = "BOOK_TITLE_REQUIRED";
            public const string SynopsisRequired = "BOOK_SYNOPSIS_REQUIRED";
            public const string SynopsisTooShort = "BOOK_SYNOPSIS_TOO_SHORT";
            public const string SynopsisTooLong = "BOOK_SYNOPSIS_TOO_LONG";
            public const string NotFound = "BOOK_NOT_FOUND";
        }

        public static class User
        {
            public const string UsernameRequired = "USER_USERNAME_REQUIRED";
            public const string EmailRequired = "USER_EMAIL_REQUIRED";
            public const string PasswordRequired = "PASSWORD_REQUIRED";
            public const string BioTooLong = "USER_BIO_TOO_LONG";
            public const string EmailDuplicate = "USER_EMAIL_EXISTS";
            public const string InvalidEmailFormat = "USER_INVALID_EMAIL_FORMAT";
            public const string InvalidCredentials = "USER_INVALID_CREDENTIALS";
            public const string NotFound = "USER_NOT_FOUND";
        }
    }
}
