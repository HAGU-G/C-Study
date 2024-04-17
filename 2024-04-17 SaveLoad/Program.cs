using System.Runtime.Serialization.Formatters;

internal class Program
{
    static void Main(string[] args)
    {
        int[] function = { 0, 1, 2, 3, 8, 9 };
        int select = -1;
        MyList<int> myList = new MyList<int>();

        while (true)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1. 추가 (뒤)\r\n2. 삭제 (뒤)\r\n3. 출력\r\n8. 저장\r\n9. 로드\r\n0. 끝");
                Console.WriteLine("\nList :");
                foreach (int i in myList)
                    Console.Write($"{i} ");
                Console.Write("\n\n명령을 입력해주세요 : ");
            } while (!int.TryParse(Console.ReadLine(), out select) || !function.Contains(select));

            switch (select)
            {
                case 0:
                    return;
                case 1:
                    Console.Write("\n추가할 숫자를 입력해주세요 : ");
                    if (int.TryParse(Console.ReadLine(), out int num))
                        myList.Add(num);
                    break;
                case 2:
                    if (myList.Count > 0)
                        myList.RemoveAt(myList.Count - 1);
                    break;
                case 8:
                    using (FileStream fs = File.Create(@".\list.txt"))
                    using (TextWriter tw = new StreamWriter(fs))
                    {
                        foreach (int i in myList)
                            tw.WriteLine(i);
                    }
                    break;
                case 9:
                    using (FileStream fs = File.OpenRead(@".\list.txt"))
                    using (TextReader tw = new StreamReader(fs))
                    {
                        myList.Clear();
                        while (tw.Peek() != -1)
                        {
                            myList.Add(int.Parse(tw.ReadLine()));
                        }
                    }
                    break;

            }
        }
    }
}
