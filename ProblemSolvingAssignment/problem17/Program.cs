using System;

namespace problem17
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input.Contains('H') || input.Contains('Q') || input.Contains('9'))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}
