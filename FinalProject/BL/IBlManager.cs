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
        public IJobBL JobBLManager { get; set; }
        public IJobSeekerBL JobSeekerBLManager { get; set; }
        public ICompanyBL CompanyBLManager { get; set; }
        public IAuth AuthManager { get; set; }
    }
}
