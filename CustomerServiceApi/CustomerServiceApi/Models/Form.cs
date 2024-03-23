namespace CustomerServiceApi.Models
{
    public class Form
    {
        public int FormId { get; set; }
        public string FormName { get; set; }
        public int AgentId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Agent Agent { get; set; }
    }
}
