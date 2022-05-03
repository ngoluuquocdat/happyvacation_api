namespace HappyVacation.DTOs.Hotels
{
    public class HotelMainInfoVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public string Address { get; set; }
        public int MinChildAge { get; set; }
        public float Rating { get; set; }
        public bool HasBreakfast { get; set; }
        public int RemainingRooms { get; set; }
        public int RemainingCapacity { get; set; }
        public bool IsSuitable { get; set; }
    }
}
