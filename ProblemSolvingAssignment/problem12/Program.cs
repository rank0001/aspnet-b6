using System;
using System.Linq;

namespace problem12
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();
            var input1 = inputs[0];
            var input2 = inputs[1];
            for (int i = 0; i < input2; i++)
            {
                int modulo = input1 % 10;
                if (modulo == 0)
                    input1 /= 10;
                else
                    input1--;
            }
            Console.WriteLine(input1);
        }
    }
}
