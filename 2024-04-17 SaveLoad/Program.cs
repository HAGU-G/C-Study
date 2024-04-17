internal class Program
{
    static void Main(string[] args)
    {
        TestAdd();
        TestInsert();
        TestRemove();
        TestRemoveAt();
        TestContains();
        TestClear();
        return; //저장, 로드 테스트하려면 주석처리

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
                    using (FileStream fs = File.Create(@".\list"))
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        foreach (int i in myList)
                        {
                            bw.Write(i);
                        }
                    }
                    break;
                case 9:
                    using (FileStream fs = File.OpenRead(@".\list"))
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        myList.Clear();
                        while (br.BaseStream.Position < br.BaseStream.Length)
                        {
                            myList.Add(br.ReadInt32());
                        }
                    }
                    break;

            }
        }
    }


    public static void TestAdd()
    {
        Console.WriteLine("Testing Add method:");

        MyList<int> myList = new MyList<int>();

        myList.Add(1);
        myList.Add(2);
        myList.Add(3);

        foreach (var item in myList)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
    }

    public static void TestInsert()
    {
        Console.WriteLine("Testing Insert method:");

        MyList<int> myList = new MyList<int>();

        myList.Add(1);
        myList.Add(2);
        myList.Add(4);

        myList.Insert(2, 3);

        foreach (var item in myList)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
    }

    public static void TestRemove()
    {
        Console.WriteLine("Testing Remove method:");

        MyList<int> myList = new MyList<int>();

        myList.Add(1);
        myList.Add(2);
        myList.Add(3);
        myList.Add(4);

        myList.Remove(3);

        foreach (var item in myList)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
    }

    public static void TestRemoveAt()
    {
        Console.WriteLine("Testing RemoveAt method:");

        MyList<int> myList = new MyList<int>();

        myList.Add(1);
        myList.Add(2);
        myList.Add(3);
        myList.Add(4);

        myList.RemoveAt(2);

        foreach (var item in myList)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
    }

    public static void TestContains()
    {
        Console.WriteLine("Testing Contains method:");

        MyList<int> myList = new MyList<int>();

        myList.Add(1);
        myList.Add(2);
        myList.Add(3);
        myList.Add(4);

        Console.WriteLine(myList.Contains(3)); // Should print true
        Console.WriteLine(myList.Contains(5)); // Should print false

        Console.WriteLine();
    }

    public static void TestClear()
    {
        Console.WriteLine("Testing Clear method:");

        MyList<int> myList = new MyList<int>();

        myList.Add(1);
        myList.Add(2);
        myList.Add(3);

        myList.Clear();

        Console.WriteLine($"Count after clearing: {myList.Count}");

        Console.WriteLine();
    }
}
