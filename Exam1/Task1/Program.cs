namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lists = new List<int> { 1, 2, 3 };
            Func<int, int, int> output = (x,y)=> (x*y);
            var value = SmartSort.Sort<int>(lists, output);
        }
        

        
    }
    public static class SmartSort { 
        public static IList<T> Sort<T>(this IList<T> elements, Func<T, T, int> compare) 
        {
            throw new NotImplementedException(); 
        } 
    }
}