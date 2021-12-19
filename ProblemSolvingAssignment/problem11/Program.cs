using System;

namespace problem11
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputValues = Console.ReadLine().Split();
            var input1 = int.Parse(inputValues[0]);
            var input2 = int.Parse(inputValues[1]);
            int year = 0;
            while (input1 <= input2)
            {
                input1 *= 3;
                input2 *= 2;
                year++;
            }
            Console.WriteLine(year);
        }
    }
}
