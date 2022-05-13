namespace HappyVacation.Database.Entities
{
    public class TravelTip
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int PlaceId { get; set; }

        // navigation props
        // 1 place - n travel tips
        public Place Place { get; set; }
    }
}
