namespace ProfileAPI.Models
{
    public class ProfileResponse
    {
        public string Status { get; set; }
        public UserInfo User { get; set; }
        public string Timestamp { get; set; }
        public string Fact { get; set; }
    }
}
