namespace HappyVacation.DTOs.Providers
{
    public class UpdateProviderRequest
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public IFormFile? Avatar { get; set; }
    }
}
