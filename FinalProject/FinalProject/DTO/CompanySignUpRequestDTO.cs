namespace API.DTO
{
    public class CompanySignUpRequestDTO
    {
        public int Code { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Rate { get; set; }
        public string? Password { get; set; }
    }
}
