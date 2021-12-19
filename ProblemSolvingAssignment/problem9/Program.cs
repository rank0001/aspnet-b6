using System;

namespace problem9
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            string team1 = "1111111";
            string team2 = "0000000";
            if (input.Contains(team1) || input.Contains(team2))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}
