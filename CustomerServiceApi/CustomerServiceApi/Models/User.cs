namespace CustomerServiceApi.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[]? Salt { get; set; }
        public byte[]? Hash { get; set; }
        public bool Active { get; set; }
        public int AgentId { get; set; }
        public Agent Agent { get; set; }
    }
}