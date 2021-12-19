using System;
using System.Collections.Generic;

namespace problem5
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine().ToLower();
            List<char> list = new List<char>();
            for (int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i] != 'a' && inputs[i] != 'i' && inputs[i] != 'o' &&
                    inputs[i] != 'e' && inputs[i] != 'u' && inputs[i] != 'y')
                {
                    list.Add('.');
                    list.Add(inputs[i]);
                }
            }
            foreach (var val in list)
                Console.Write(val);
        }
    }
}
