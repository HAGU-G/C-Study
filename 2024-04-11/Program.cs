using System.Collections;
using System.Numerics;
using System.Text;

namespace _2024_04_11
{
    public static class StringExtention
    {
        public static string Reverse(this string s) //this를 붙이면 확장 메소드가 된다.
        {
            StringBuilder temp = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                temp.Append(s[i]);
            }
            return temp.ToString();

            //return new string(s.Reverse<char>().ToArray());
        }

        public static void DoubleAll<T>(this IList<T> list) where T : IAdditionOperators<T, T, T> 
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] += list[i];
            }
        }

        public static int Square(this int num)
        {
            return num * num;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test Reverse
            string original = "hello";
            string reversed = original.Reverse();
            Console.WriteLine(reversed);    // olleh
            Console.WriteLine();

            // Test DoubleAll
            List<int> originalList = new List<int> { 1, 2, 3 };
            originalList.DoubleAll();
            originalList.ForEach(Console.WriteLine);    // 2, 4, 6
            Console.WriteLine();

            // Test Square
            int originalNum = 4;
            int squared = originalNum.Square();
            Console.WriteLine(squared); // 16
            Console.WriteLine();
        }

    }

}
