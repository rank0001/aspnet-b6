using System;
using System.Collections.Generic;

namespace problem8
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<char> hashValues = new HashSet<char>();
            var values = Console.ReadLine();
            foreach (var item in values)
            {
                hashValues.Add(item);
            }
            if (hashValues.Count % 2 == 0)
                Console.WriteLine("CHAT WITH HER!");
            else
                Console.WriteLine("IGNORE HIM!");
        }
    }
}
