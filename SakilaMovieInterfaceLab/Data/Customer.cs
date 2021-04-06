﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SakilaMovieInterfaceLab.Data
{
    public partial class Customer
    {
        public Customer()
        {
            Payments = new HashSet<Payment>();
            Rentals = new HashSet<Rental>();
        }

        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public string Active { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Address Address { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
