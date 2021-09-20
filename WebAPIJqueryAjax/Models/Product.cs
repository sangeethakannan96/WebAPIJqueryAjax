using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIJqueryAjax.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Active { get; set; }
    }
}