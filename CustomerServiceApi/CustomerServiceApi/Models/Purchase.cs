namespace CustomerServiceApi.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int PhurchaseAmount { get; set; }
        public string PurchaseType { get; set; }
        public int FormId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Form Form { get; set; }
    }
}
