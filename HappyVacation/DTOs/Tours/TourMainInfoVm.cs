namespace HappyVacation.DTOs.Tours
{
    public class TourMainInfoVm
    {
        public int Id { get; set; }
        public string TourName { get; set; }
        public int Reviews { get; set; }
        public float Rating { get; set; }
        public bool IsPrivate { get; set; }
        public int MinPrice { get; set; }
        public float Duration { get; set; }
        public string ThumbnailPath { get; set; }
    }
}
