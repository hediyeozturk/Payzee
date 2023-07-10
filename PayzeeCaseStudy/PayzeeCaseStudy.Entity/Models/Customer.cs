namespace PayzeeCaseStudy.Entity.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateTime? BirthDate { get; set; }

    public string? IdentityNo { get; set; }

    public bool IdentityNoVerified { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
