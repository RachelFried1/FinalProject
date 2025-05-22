using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class CompanyNotFoundException : Exception
    {
        public int StatusCode { get; }
        public CompanyNotFoundException(int CompanyCode) : base($"The company with Id {CompanyCode} was not found!")
        {
            StatusCode = 404;
        }
    }
    public class CompanyAlreadyExistsException : Exception
    {
        public int StatusCode { get; }
        public CompanyAlreadyExistsException(int CompanyCode) : base($"The seeker with Id {CompanyCode} already exists!")
        {
            StatusCode = 409;
        }
    }
}
