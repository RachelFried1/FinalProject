using BL.Api;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class JobOffersServiceBL : IJobOffersBL
    {
        public JobOffersServiceBL()
        {
            
        }

        public List<JobSeekerBL> FindCandidatesByJobCode(int jobCode)
        {
            throw new NotImplementedException();
        }

        public List<JobBL> FindMatchesById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
