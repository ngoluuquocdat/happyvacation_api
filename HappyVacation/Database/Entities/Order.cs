namespace HappyVacation.Database.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public string State { get; set; }
        public string? CancelReason { get; set; }
        public string TouristIdentityNum { get; set; }
        public string TouristName { get; set; }
        public string TouristPhone { get; set; }
        public string TouristEmail { get; set; }
        public string TransactionId { get; set; }
        public int TourId { get; set; }
        //public int ProviderId { get; set; }
        public int UserId { get; set; }

        // navigation props
        public Tour Tour { get; set; }
        public User User { get; set; }
        public List<OrderMember> OrderMembers { get; set; }
        //public Provider Provider { get; set; }
    }
}
