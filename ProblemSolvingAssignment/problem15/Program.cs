using System;
using System.Linq;

namespace problem15
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int maxPassenger = 0, totalPassenger = 0;
            for (int i = 0; i < input; i++)
            {
                var inputLines = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();
                var enter = inputLines[1];
                var exit = inputLines[0];
                totalPassenger -= exit;
                totalPassenger += enter;
                maxPassenger = Math.Max(maxPassenger, totalPassenger);
            }
            Console.WriteLine(maxPassenger);
        }
    }
}
