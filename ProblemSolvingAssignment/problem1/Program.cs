using System;

namespace problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int i = 0; i < input; i++)
            {
                string inputString = Console.ReadLine();
                string resultString;
                if (inputString.Length > 10)
                {
                    resultString = inputString[0] + Convert.ToString(inputString.Length - 2) + inputString[^1];
                    Console.Write(resultString);
                }
                else
                    Console.Write(inputString);
                Console.WriteLine();
            }

        }

    }

}