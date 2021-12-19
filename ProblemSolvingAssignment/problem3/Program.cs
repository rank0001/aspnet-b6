using System;

namespace problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] val = new int[5, 5];
            int a = 0, b = 0;
            for (int i = 0; i < 5; i++)
            {
                var values = Console.ReadLine().Split();
                for (int j = 0; j < 5; j++)
                {
                    val[i, j] = int.Parse(values[j]);
                }
            }
            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j] == 1)
                    {
                        a = i + 1;
                        b = j + 1;
                        break;
                    }
                }
            }
            int c = Math.Abs(3 - a) + Math.Abs(b - 3);
            Console.WriteLine(c);

        }
    }
}
