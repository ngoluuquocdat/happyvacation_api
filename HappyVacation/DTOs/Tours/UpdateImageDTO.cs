namespace HappyVacation.DTOs.Tours
{
    public class UpdateImageDTO
    {
        public int Id { get; set; }
        public IFormFile? File { get; set; }
        public bool Deleted { get; set; }
    }
}
