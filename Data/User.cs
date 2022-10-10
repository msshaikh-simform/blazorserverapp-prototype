﻿using System;
using System.ComponentModel.DataAnnotations;

namespace QuotationMgmtSystem.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}