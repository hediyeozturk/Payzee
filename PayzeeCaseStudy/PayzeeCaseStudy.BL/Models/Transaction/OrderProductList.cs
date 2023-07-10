namespace PayzeeCaseStudy.BL.Models.Transaction
{
    public class OrderProductList
    {
        public int merchantId { get; set; }
        public string productId { get; set; }
        public string amount { get; set; }
        public string productName { get; set; }
        public string commissionRate { get; set; }
    }
}
