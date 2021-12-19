using System;

namespace problem14
{
    class Program
    {
        static void Main(string[] args)
        {
            string letter = Console.ReadLine();
            int upper = 0, lower = 0;
            foreach (var item in letter)
            {
                if (Char.IsUpper(item))
                    upper++;
                else
                    lower++;
            }
            if (upper > lower)
                Console.Write(letter.ToUpper());
            else
                Console.Write(letter.ToLower());
        }
    }
}
