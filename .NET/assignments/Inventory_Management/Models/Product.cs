using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Inventory_Management.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }

    //[JsonIgnore]
    //public virtual Category Category { get; set; }
}
