using System;

namespace problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString1 = Console.ReadLine().ToLower();
            var inputString2 = Console.ReadLine().ToLower();
            Console.WriteLine(inputString1.CompareTo(inputString2));
        }
    }
}
