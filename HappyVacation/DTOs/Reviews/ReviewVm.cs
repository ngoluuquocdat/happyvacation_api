namespace HappyVacation.DTOs.Reviews
{
    public class ReviewVm
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Content { get; set; }
        public float Rating { get; set; }
        public string Username { get; set; }
        public string UserAvatar { get; set; }
    }
}
