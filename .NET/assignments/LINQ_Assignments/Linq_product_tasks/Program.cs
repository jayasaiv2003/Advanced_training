using Linq_product_tasks;

//Product Data

var products = new List<Product>
            {
                new Product{ Id=1, Name="Laptop", Category="Electronics", Price=75000, Stock=15 },
                new Product{ Id=2, Name="Smartphone", Category="Electronics", Price=55000, Stock=25 },
                new Product{ Id=3, Name="Tablet", Category="Electronics", Price=30000, Stock=10 },
                new Product{ Id=4, Name="Headphones", Category="Accessories", Price=2000, Stock=100 },
                new Product{ Id=5, Name="Shirt", Category="Fashion", Price=1500, Stock=50 },
                new Product{ Id=6, Name="Jeans", Category="Fashion", Price=2200, Stock=30 },
                new Product{ Id=7, Name="Shoes", Category="Fashion", Price=3500, Stock=20 },
                new Product{ Id=8, Name="Refrigerator", Category="Appliances", Price=45000, Stock=8 },
                new Product{ Id=9, Name="Washing Machine", Category="Appliances", Price=38000, Stock=6 },
                new Product{ Id=10, Name="Microwave", Category="Appliances", Price=12000, Stock=12 }
            };


Console.WriteLine("1.Display all products with stock less than 20.");

Console.WriteLine("task 1");
var lowStockthan20 = products.Where(p => p.Stock < 20);

foreach (var product in lowStockthan20)
{
    Console.WriteLine($" Name: {product.Name}");
}

Console.WriteLine("---------------------------------------------------");
Console.WriteLine("2.Show all products belonging to the “Fashion” category.")
Console.WriteLine("task 2");
var fashionProducts = products.Where(p => p.Category == "Fashion");
foreach (var product in fashionProducts)
{
    Console.WriteLine($" Name: {product.Name}");
}

Console.WriteLine("---------------------------------------------------");
Console.WriteLine("task 3");
Console.WriteLine("3. Display product names and prices where price is greater than 10,000.")

var Productsmorethan10000 = products.Where(p => p.Price > 10000)
                                .Select(g => $"{g.Name}--{g.Price}");
foreach (var product in Productsmorethan10000)
    {
    Console.WriteLine(product);
}

Console.WriteLine("---------------------------------------------------");
Console.WriteLine("task 4");
Console.WriteLine("4. List all product names sorted by price (descending).");
//4. List all product names sorted by price (descending).

var sortedProducts = products.OrderByDescending(p => p.Price);
                             
foreach (var product in sortedProducts)
{
    Console.WriteLine(product.Name);
}

Console.WriteLine("---------------------------------------------------");
//5.Find the most expensive product in each category.
 Console.WriteLine("task 5");
var mostexpensiveineach = products.GroupBy(p => p.Category)
                                    .Select(g => new
                                    {
                                        Category = g.Key,
                                        Maxexpensive = g.Max(p => p.Stock)
                                    });

foreach (var item in mostexpensiveineach)
{
    Console.WriteLine($"Category: {item.Category}, Most Expensive Stock: {item.Maxexpensive}");
}

    Console.WriteLine("---------------------------------------------------");


//6.Show total stock per category.
Console.WriteLine("task 6");
var totalStockPerCategory = products.GroupBy(p => p.Category)
                                    .Select(g => new
                                    {
                                        Category = g.Key,
                                        TotalStock = g.Sum(p => p.Stock)
                                    });
foreach (var item in totalStockPerCategory)
{
    Console.WriteLine($"Category: {item.Category}, Total Stock: {item.TotalStock}");
}

Console.WriteLine("---------------------------------------------------");


//7.Display products whose name starts with ‘S’.
Console.WriteLine("task 7");
var productsStartingWithS = products.Where(p => p.Name.StartsWith("S"));
foreach (var product in productsStartingWithS)
{
    Console.WriteLine($"Name: {product.Name}");
}

//8.Show average price of products in each category.
Console.WriteLine("---------------------------------------------------");
Console.WriteLine("task 8");
var averagePricePerCategory = products.GroupBy(p => p.Category)
                                     .Select(g => new
                                     {
                                         Category = g.Key,
                                         AveragePrice = g.Average(p => p.Price)
                                     });
foreach (var item in averagePricePerCategory)
    {
    Console.WriteLine($"Category: {item.Category}, Average Price: {item.AveragePrice}");
}
Console.WriteLine("---------------------------------------------------");

