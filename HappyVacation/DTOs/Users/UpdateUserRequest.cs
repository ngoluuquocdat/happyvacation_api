namespace HappyVacation.DTOs.Users
{
    public class UpdateUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public IFormFile? Avatar { get; set; }
    }
}
