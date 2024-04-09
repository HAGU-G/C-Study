namespace _2024_04_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            var a = Function().GetEnumerator();
            a.MoveNext();
            Console.WriteLine(a.Current);
            a.MoveNext();
            Console.WriteLine(a.Current);
            a.MoveNext();
            Console.WriteLine(a.Current);
            a = Function().GetEnumerator();
            a.MoveNext();
            Console.WriteLine(a.Current);
            a.MoveNext();
            Console.WriteLine(a.Current);






            IEnumerable<int> Function()
            {
                int minus = 1;
                for (int i = 0; i < 10; i++)
                {
                    yield return i * minus;
                    minus *= -1;
                }
            }
        }
    }
}
