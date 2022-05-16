namespace HappyVacation.Database.Entities
{
    public class OrderMember
    {
        public int Id { get; set; }
        public string IdentityNum { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsChild { get; set; }
        public int OrderId { get; set; }

        // navigation props
        public Order Order { get; set; }
    }
}
