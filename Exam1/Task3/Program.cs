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
                new Customer{Name = "afsar",Id=4}
            };
            List<Order> orders = new List<Order>
            {
                new Order{CustomerId=1,ProductName="pen",Quantity=3},
                new Order{CustomerId=2,ProductName="bottle",Quantity=2},
                new Order{CustomerId=3,ProductName="fan",Quantity=5},
                new Order{CustomerId=5,ProductName="bedsheet",Quantity=20}

            };

            var query =
            from o in orders
            join c in customers on o.CustomerId equals c.Id
            select new
            {
                c.Name,
                o.ProductName,
                o.Quantity
            };

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
