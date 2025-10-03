namespace DisasterManagementApp.Models
{
    public class Resource
    {
        public int ResourceID { get; set; }
        public int DonationID { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public int Quantity { get; set; }
    }
}
