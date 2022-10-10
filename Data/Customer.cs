﻿using System;
using System.ComponentModel.DataAnnotations;

namespace QuotationMgmtSystem.Data
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}