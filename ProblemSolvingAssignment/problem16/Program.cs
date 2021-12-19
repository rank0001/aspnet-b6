using System;
using System.Collections.Generic;

namespace problem16
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string output = "hello";
            int i = 0;
            foreach (var item in input)
            {
                if (item == output[i])
                {
                    i++;
                    if (i == 5)
                        break;
                }
            }
            Console.WriteLine(i == 5 ? "YES" : "NO");
        }
    }
}
