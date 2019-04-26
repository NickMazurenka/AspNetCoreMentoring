﻿using System.Collections.Generic;
using NorthwindTraders.Adapters.Driving.Web.ViewModels.Product;

namespace NorthwindTraders.Adapters.Driving.Web.ViewModels.Supplier
{
    public class SupplierViewModel
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }

        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}
