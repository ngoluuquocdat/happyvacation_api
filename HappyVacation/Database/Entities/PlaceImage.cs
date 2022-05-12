namespace HappyVacation.Database.Entities
{
    public class PlaceImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int PlaceId { get; set; }

        // navigation props
        // 1 place - n place images
        public Place Place { get; set; }
    }
}
