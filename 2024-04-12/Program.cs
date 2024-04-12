namespace _2024_04_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
////////////////////////////////////// 1
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



////////////////////////////////////// 2
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

////////////////////////////////////// 3
            {
                // code from DevCurry.com
                var arr1 = new[] { 3, 9, 2, 8, 6, 5 };

                Console.Write("\nLINQ : Find the number and its square of an array which is more than 20 : ");
                Console.Write("\n------------------------------------------------------------------------\n");

                var sqNo = arr1
                    .Select(x => new { Number = x, SqrNo = x * x })
                    .Where(x => x.SqrNo >= 20)
                    .OrderByDescending(x => x.Number);


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



////////////////////////////////////// 4
            {
                
                // Find the words in the collection that start with the letter 'L'
                List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

                IEnumerable<string> LFruits = from x in fruits
                                              where x[0] == 'L'
                                              select x;
                Console.WriteLine();
                foreach (string fruit in LFruits)
                {
                    Console.WriteLine(fruit);
                }

                // Lemon
                // Lime
                // Loganberry


                // Which of the following numbers are multiples of 4 or 6
                List<int> mixedNumbers = new List<int>()
                {
                    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
                };

                List<int> fourSixMultiples = (from x in mixedNumbers
                                             where x % 4 == 0 || x % 6 == 0
                                             select x).ToList();
                Console.WriteLine();
                foreach (int number in fourSixMultiples)
                {
                    Console.WriteLine(number);
                }

                //8
                //24
                //32
                //30
                //12
                //54
                //48
                //4
                //96


                List<string> names = new List<string>()
                {
                    "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                    "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                    "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                    "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                    "Francisco", "Tre"
                };

                List<string> descending = names.OrderDescending().ToList();
                Console.WriteLine();
                foreach (string item in descending)
                {
                    Console.WriteLine(item);
                }


                // How much money have we made?
                List<double> purchases = new List<double>()
                {
                    2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
                };
                Console.WriteLine();
                Console.WriteLine($"{Math.Round(purchases.Sum())}"); // 20,750

                // What is our most expensive product?
                List<double> prices = new List<double>()
                {
                    879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
                };
                Console.WriteLine();
                Console.WriteLine($"{Math.Round(prices.Max())}"); // 9,443

                /*
                    Store each number in the following List until a perfect square
                    is detected.

                    Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
                */
                List<int> wheresSquaredo = new List<int>()
                {
                    66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
                };

                List<int> nonSquares = new(wheresSquaredo.TakeWhile(x => Math.Sqrt(x) % 1d != 0d));
                Console.WriteLine();
                foreach (var item in nonSquares)
                {
                    Console.WriteLine(item.ToString());
                }

                //66
                //12
                //8
                //27
                //82
                //34
                //7
                //50
                //19
                //46


            }








        }
    }
}
