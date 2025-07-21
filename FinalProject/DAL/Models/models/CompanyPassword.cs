using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

<<<<<<< HEAD
=======

using System.Text.Json.Serialization;

>>>>>>> b30581dcf064fb04ced3d8fd221c8ae4a56cff17
namespace DAL.Models.models
{
    public class CompanyPassword
    {
        public int Id { get; set; }
        public string? PasswordHash { get; set; }
        public int CompanyId { get; set; }
        [JsonIgnore]
<<<<<<< HEAD
        public Company? Company { get; set; }
=======
        public Company Company { get; set; }
>>>>>>> b30581dcf064fb04ced3d8fd221c8ae4a56cff17
    }

}