using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class SeekerAlreadyExistsException : Exception
    {
        public int StatusCode { get; }
        public SeekerAlreadyExistsException(int SeekerId) : base($"The seeker with Id {SeekerId} already exists!")
        {
            StatusCode = 409;
        }
    }

    public class SeekerNotFoundException : Exception
    {
        public int StatusCode { get; }
        public SeekerNotFoundException(int SeekerId) : base($"The seeker with Id {SeekerId} was not found!")
        {
            StatusCode = 404;
        }
    }
    
}
