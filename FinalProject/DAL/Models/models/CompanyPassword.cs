

namespace DAL.Models.models
{
    public class CompanyPassword
    {
        public int Id { get; set; }
        public string PasswordHash { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }

}