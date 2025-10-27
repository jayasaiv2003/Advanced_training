using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_order_tasks
{
    internal class Order
    {
       
            public int OrderId { get; set; }
            public int CustomerId { get; set; }
            public decimal Amount { get; set; }
            public DateTime OrderDate { get; set; }

    
    }
}
