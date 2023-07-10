namespace PayzeeCaseStudy.API.Models
{
    public class UserModel
    {
        public string Email { get; set; }
        public string ApiKey { get; set; }
        public string Lang { get; set; }
        public string Password { get; set; }
        public int MemberID { get; set; }
        public int MerchantId { get; set; }
        public string UserType { get; set; }
    }
}
