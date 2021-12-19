using System;
using System.Collections.Generic;

namespace problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            List<int> list = new List<int>();
            foreach (var item in input)
            {
                if (item >= '1' && item <= '3')
                {
                    list.Add(item - '0');
                }
            }
            list.Sort();
            int i = 0;
            foreach (var item in list)
            {

                Console.Write(item);
                if (i != list.Count - 1)
                    Console.Write("+");
                i++;
            }
        }
    }
}
