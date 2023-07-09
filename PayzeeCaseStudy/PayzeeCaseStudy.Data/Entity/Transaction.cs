//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PayzeeCaseStudy.Data.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string OrderId { get; set; }
        public string TypeId { get; set; }
        public string Amount { get; set; }
        public string CardPan { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string Status { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}
