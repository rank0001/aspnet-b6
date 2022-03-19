namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            DateTime datetime = DateTime.Parse(input);

            string output = datetime.ToString("HH:mm");

            Console.WriteLine(output);
            

        }
    }
}