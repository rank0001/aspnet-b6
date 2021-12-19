using System;

namespace problem7
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string stringInput = Console.ReadLine();
            int res = 0;
            for (int i = 0; i < input - 1; i++)
            {
                if (stringInput[i] == stringInput[i + 1])
                {
                    char charValue = stringInput[i];
                    i++;
                    while (i < input && charValue == stringInput[i])
                    {
                        i++;
                        res++;
                    }
                    i--;
                }
            }
            Console.WriteLine(res);
        }
    }
}
