using DAL.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDalManager
    {
         IJob JobManager { get; set; }
         IJobSeeker JobSeekerManager { get; set; }
         IJobOffers JobOffersManager { get; set; }
       
    }
}
