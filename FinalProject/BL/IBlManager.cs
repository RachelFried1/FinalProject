using BL.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBlManager
    {
        IJobBL JobBLManager { get; set; }
        IJobSeekerBL JobSeekerBLManager { get; set; }
        IJobOffersBL JobOffersBLManager { get; set; }
    }
}
