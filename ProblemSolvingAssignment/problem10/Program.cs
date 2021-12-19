using System;

namespace problem10
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split();
            var cost = int.Parse(inputs[0]);
            var cash = int.Parse(inputs[1]);
            var bananas = int.Parse(inputs[2]);
            var totalCost = ((bananas * (bananas + 1) / 2) * cost) - cash;
            if (totalCost <= 0)
                Console.WriteLine(0);
            else
                Console.WriteLine(totalCost);


        }
    }
}
