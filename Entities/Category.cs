using System;
using System.Collections.Generic;

namespace IdentitySample.Entities
{
    public partial class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? Status { get; set; }
    }
}
