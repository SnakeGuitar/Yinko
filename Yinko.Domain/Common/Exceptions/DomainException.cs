using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Yinko.Domain.Common.Exceptions
{
    public abstract class DomainException : Exception
    {
        public string Code { get; }
        protected DomainException(string code, string message) : base(message) 
        {
            Code = code;
        }
    }

    public class InvalidBookException : DomainException
    {
        public InvalidBookException(string code, string message)
            : base(code, message) { }
    }

    public class InvalidUserException : DomainException
    {
        public InvalidUserException(string code, string message)
            : base(code, message) { }
    }

    public class NotFoundException : DomainException
    {
        public NotFoundException(string code, string name, object key)
            : base(code, $"Entity \"{name}\" ({key}) was not found.") { }
    }
}
