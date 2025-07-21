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
        public SeekerNotFoundException(string SeekerEmail) : base($"The seeker with email {SeekerEmail} was not found!")
        {
            StatusCode = 404;
        }
    }

    public class SeekerAlreadyActiveException : Exception
    {
        public int StatusCode { get; }
        public SeekerAlreadyActiveException(int SeekerId) : base($"The seeker with Id {SeekerId} is already active, cannot activate!")
        {
            StatusCode = 409;
        }
    }

    public class SeekerNotActiveException : Exception
    {
        public int StatusCode { get; }
        public SeekerNotActiveException(int SeekerId) : base($"The seeker with Id {SeekerId} is not active!")
        {
            StatusCode = 404;
        }
    }

    public class SeekerAlreadyAppliedException : Exception
    {
        public int StatusCode { get; }
        public SeekerAlreadyAppliedException(int SeekerId) : base($"The seeker with Id {SeekerId} is already applied, cannot apply!")
        {
            StatusCode = 409;
        }
    }

    public class SeekerNotAppliedException : Exception
    {
        public int StatusCode { get; }
        public SeekerNotAppliedException(int SeekerId) : base($"The seeker with Id {SeekerId} is not applied!")
        {
            StatusCode = 404;
        }
    }

}
