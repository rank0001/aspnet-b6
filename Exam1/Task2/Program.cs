namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            char[] chars = input.ToCharArray();
            int cnt = 0;
            while (cnt < count)
            {
                char temp=chars[0];
                char chng = temp;
                if (cnt == count)
                    break;
                for(int i = 0; i < chars.Length-1; i++)
                {
                    
                    temp = chars[i+1];
                    chars[i+1] = chng;
                    chng = temp;
                }
                chars[0] = chng;
                cnt++;
            }
            Console.WriteLine("The rotated string is:");
            foreach (var item in chars)
            {
                Console.Write(item);
            }
            Console.WriteLine();

        }
    }
}