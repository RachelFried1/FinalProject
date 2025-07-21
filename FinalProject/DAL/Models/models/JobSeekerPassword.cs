using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Models.models
{
    public class JobSeekerPassword
    {
        public int Id { get; set; }
        public string PasswordHash { get; set; }
        public int JobSeekerId { get; set; }
        [JsonIgnore]
        public JobSeeker JobSeeker { get; set; }
    }
}
