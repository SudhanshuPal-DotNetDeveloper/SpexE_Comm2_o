using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SpexE_Comm.Data.Data
{
    public partial class Products
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductImage1 { get; set; }
        public string ProductImage2 { get; set; }
        public string ProductImage3 { get; set; }
        public string ProductImage4 { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsAssured { get; set; }
        public bool IsDeliveryFreeOrNot { get; set; }
        public int? DiscountPrice { get; set; }
        public int? Rating { get; set; }
        public string Warranty { get; set; }
        public string BrandName { get; set; }
    }
}
