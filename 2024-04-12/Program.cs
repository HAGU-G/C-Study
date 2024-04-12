namespace _2024_04_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                //  The first part is Data source.
                int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                Console.Write("\nBasic structure of LINQ : ");
                Console.Write("\n---------------------------");

                // The second part is Query creation.
                // nQuery is an IEnumerable<int>
                var nQuery = from x in n1
                             where x % 2 == 0
                             select x;

                // The third part is Query execution.

                Console.Write("\nThe numbers which produce the remainder 0 after divided by 2 are : \n");
                foreach (int VrNum in nQuery)
                {
                    Console.Write("{0} ", VrNum);
                }
                Console.Write("\n\n");
                // OUTPUT: 0 2 4 6 8
            }




            {
                int[] n1 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };

                Console.Write("\nLINQ : Using multiple WHERE clause to find the positive numbers within the list : ");
                Console.Write("\n-----------------------------------------------------------------------------");

                var nQuery = from x in n1
                             where x >= 1
                             where x <= 11
                             select x;

                Console.Write("\nThe numbers within the range of 1 to 11 are : \n");
                foreach (var VrNum in nQuery)
                {
                    Console.Write("{0}  ", VrNum);
                }
                Console.Write("\n\n");
                // OUTPUT: 1 3 6 9 10
            }

            {
                // code from DevCurry.com
                var arr1 = new[] { 3, 9, 2, 8, 6, 5 };

                Console.Write("\nLINQ : Find the number and its square of an array which is more than 20 : ");
                Console.Write("\n------------------------------------------------------------------------\n");

                var sqNo = arr1.Where(x => x * x >= 20)
                               .Order()
                               .Reverse()
                               .Select(x => new { Number = x, SqrNo = x * x });

                foreach (var a in sqNo)
                    Console.WriteLine(a);

                // OUTPUT: 
                /*
                { Number = 9, SqrNo = 81 }
                { Number = 8, SqrNo = 64 }
                { Number = 6, SqrNo = 36 }
                { Number = 5, SqrNo = 25 }
                */
            }
        }
    }
}
