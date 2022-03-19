namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Customer> customers = new List<Customer>
            {
                new Customer{Name="sakib",Id=1},
                new Customer{Name="rakib",Id=2},
                new Customer{Name = "ahsan",Id=3},
            };
            List<Order> orders = new List<Order>
            {
                new Order{CustomerId=1,ProductName="pen",Quantity=3},
                new Order{CustomerId=2,ProductName="bottle",Quantity=2},
                new Order{CustomerId=3,ProductName="fan",Quantity=5},

            };

            var query =
            orders.Join(customers, o => o.CustomerId, c => c.Id, (o, c)
              => new
                {
                    Pname = o.ProductName,
                    Cname = c.Name,
                    PQuantity = o.Quantity
                }).AsEnumerable()
                .Select(o => new Tuple<string, string, int>(o.Pname, o.Cname, o.PQuantity))
                .ToList();

            foreach (var item in query)
            {
                Console.WriteLine(item.Item1 + " " + item.Item2 + " " + item.Item3);
            }



        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    public class Order
    {
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }

}
