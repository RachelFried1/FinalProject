using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    
        public class OfferNotFoundException : Exception
        {
            public int StatusCode { get; }
            public OfferNotFoundException(int OfferCode) : base($"The offer with code {OfferCode} was not found!")
            {
                StatusCode = 404;
            }
        }
        public class OfferAlreadyExistsException : Exception
        {
            public int StatusCode { get; }
            public OfferAlreadyExistsException(int OfferCode) : base($"The offer with code {OfferCode} already exists!")
            {
                StatusCode = 409;
            }
        }
    }

