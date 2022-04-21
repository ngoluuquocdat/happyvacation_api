using HappyVacation.DTOs.Places;

namespace HappyVacation.DTOs.Tours
{
    public class TourMainInfoManageVm
    {
        public int Id { get; set; }
        public string TourName { get; set; }
        public bool IsPrivate { get; set; }
        public float Duration { get; set; }
        public int GroupSize { get; set; }
        public int PricePerAdult { get; set; }
        public int PricePerChild { get; set; }
        public IEnumerable<PlaceVm> Places { get; set; }
        public IEnumerable<CategoryVm> Categories { get; set; }
        public string ThumbnailPath { get; set; }
        public float Rating { get; set; }
        public int Reviews { get; set; }
        public int OrderCount { get; set; }
        public bool IsAvailable { get; set; }
    }
}
