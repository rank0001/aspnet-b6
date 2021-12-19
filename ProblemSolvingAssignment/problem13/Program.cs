using System;

namespace problem13
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(input % 5 == 0 ? input / 5 : input / 5 + 1);
        }
    }
}
