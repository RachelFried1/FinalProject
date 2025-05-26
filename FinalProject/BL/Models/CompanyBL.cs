using DAL.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class CompanyBL
    {
        public int Code { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int Rate { get; set; }

    }
}
