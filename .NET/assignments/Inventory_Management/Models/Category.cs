using System;
using System.Collections.Generic;

namespace Inventory_Management.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;


    //public virtual ICollection<Product> Products { get; set; }
}
