using System;
using System.ComponentModel.DataAnnotations;

namespace QuotationMgmtSystem.Data
{
    public class Quotation
    {
        [Key]
        public int QuoteId { get; set; }
        public string ProjectName{ get; set; }
        public DateTime? BidReceiptDate { get; set; }
        public DateTime? BidSubmissionDate { get; set; }
        public string Notes { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}