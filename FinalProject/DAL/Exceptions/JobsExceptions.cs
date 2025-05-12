using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class JobNotFoundException : Exception
    {
        public int StatusCode { get; }
        public JobNotFoundException(int JobCode) : base($"The seeker with Id {JobCode} was not found!")
        {
            StatusCode = 404;
        }
    }
    public class JobAlreadyExistsException : Exception
    {
        public int StatusCode { get; }
        public JobAlreadyExistsException(int JobCode) : base($"The seeker with Id {JobCode} already exists!")
        {
            StatusCode = 409;
        }
    }
}
