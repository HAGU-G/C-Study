namespace _2024_04_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Dictionary<int, string> list2 = new Dictionary<int, string> { { 1, "ㅁㄴㅇㄹ" }, { 2, "ㅂㅈㄷㄱj" } };

            var linqList = from x in list2
                           where x.Key % 2 == 0
                           where x.Value.Length > 4
                           select x;

            foreach (var x in linqList)
            {
                Console.WriteLine(x);
            }





            string[] names = { "Tom", "Dick", "Harry" };
            var fliteredNames = from n in names
                                where n.Length % 2 == 1
                                select n;

            foreach (var n in fliteredNames)
            {
                Console.WriteLine(n);
            }
        }
    }
}
