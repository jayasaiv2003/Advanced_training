using Linq_order_tasks;

//Order Data

var orders = new List<Order>
            {
                new Order{ OrderId=1001, CustomerId=1, Amount=2500, OrderDate=new DateTime(2025,5,12)},
                new Order{ OrderId=1002, CustomerId=2, Amount=1800, OrderDate=new DateTime(2025,5,13)},
                new Order{ OrderId=1003, CustomerId=1, Amount=4500, OrderDate=new DateTime(2025,5,20)},
                new Order{ OrderId=1004, CustomerId=3, Amount=6700, OrderDate=new DateTime(2025,6,01)},
                new Order{ OrderId=1005, CustomerId=4, Amount=2500, OrderDate=new DateTime(2025,6,02)},
                new Order{ OrderId=1006, CustomerId=2, Amount=5600, OrderDate=new DateTime(2025,6,10)},
                new Order{ OrderId=1007, CustomerId=5, Amount=3100, OrderDate=new DateTime(2025,6,12)},
                new Order{ OrderId=1008, CustomerId=3, Amount=7100, OrderDate=new DateTime(2025,7,01)},
                new Order{ OrderId=1009, CustomerId=4, Amount=4200, OrderDate=new DateTime(2025,7,05)},
                new Order{ OrderId=1010, CustomerId=5, Amount=2900, OrderDate=new DateTime(2025,7,10)}
            };


//1.Find total order amount per month.
var totalAmountPerMonth = orders
    .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month });
foreach (var group in totalAmountPerMonth)
{
    Console.WriteLine($"Year : {group.Key.Year} Month :{group.Key.Month} total order_amount: {group.Sum(o=>o.Amount)}");
}
//2.Show the customer who spent the most in total.
Console.WriteLine("-------------------------------------------");
var customerspentmost = orders.GroupBy(o => o.CustomerId).Select(
    o => new
    {
        CustomerId = o.Key,
        total = o.Sum(o => o.Amount),
    });
//
var spentmostintotal = customerspentmost.OrderByDescending(o => o.total).FirstOrDefault();
Console.WriteLine($"customer spent most : {spentmostintotal}");

//3.Display orders grouped by customer and show total amount spent.
Console.WriteLine("--------------------------------------");
var customerspentamount = orders.GroupBy(o => o.CustomerId);
foreach (var group in customerspentamount)
{
    Console.WriteLine($"customer id : {group.Key}, total spent : {group.Sum(o => o.Amount)}");
}


Console.WriteLine("--------------------------------------");

//4.Display the top 2 orders with the highest amount.
var top2orders = orders.OrderBy(o => o.Amount).Take(2);

foreach (var order in top2orders)
{
    Console.WriteLine($"orderid : {order.OrderId}");
}


