using System;

namespace problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int result = 0;
            for (int i = 0; i < input; i++)
            {
                string inputString = Console.ReadLine();
                if (inputString[1] == '+')
                    result++;
                else
                    result--;
            }
            Console.WriteLine(result);
        }
    }
}
