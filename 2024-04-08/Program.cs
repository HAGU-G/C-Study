namespace _2024_04_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];

            try
            {
                for (int i = 0; i < 10; i++)
                    arr[i] = i;

                for (int i = 0; i < 11; i++)
                    Console.WriteLine(arr[i]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("처리되지 않은 예외");
            }
        }
    }
}
