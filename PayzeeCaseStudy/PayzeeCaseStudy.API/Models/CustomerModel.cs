namespace PayzeeCaseStudy.API.Models
{
    public class CustomerModel
    {
        public int? CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string IdentityNo { get; set; }
        public bool? IdentityNoVerified { get; set; }
    }
}
