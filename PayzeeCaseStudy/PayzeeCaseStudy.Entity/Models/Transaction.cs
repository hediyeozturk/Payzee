namespace PayzeeCaseStudy.Entity.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? CustomerId { get; set; }

    public string? OrderId { get; set; }
    public string? Request { get; set; }
    public string? Response { get; set; }
    public string? TransactionType { get; set; }
    public string? Amount { get; set; }
    public string? CardPan { get; set; }
    public string? ResponseCode { get; set; }
    public string? Status { get; set; }
    public virtual Customer? Customer { get; set; }

}
