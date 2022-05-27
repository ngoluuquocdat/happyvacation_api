namespace HappyVacation.DTOs.Orders
{
    public class OrderedTourists
    {
        public int OrderId { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public IEnumerable<AdultVm> AdultsList { get; set; }
        public IEnumerable<ChildVm> ChildrenList { get; set; }
    }
}
