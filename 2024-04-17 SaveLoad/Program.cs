using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;

internal class Program
{


    static void Main(string[] args)
    {
        #region MYLIST_TEST
        // 실습 3번 (MyList)
        //TestAdd();
        //TestInsert();
        //TestRemove();
        //TestRemoveAt();
        //TestContains();
        //TestClear();
        //return; //저장, 로드 테스트하려면 주석처리
        #endregion

        int[] function = { 0, 1, 2, 3, 4, 6, 7, 8, 9 };
        int select = -1;
        int num = 0; //추가할 숫자
        List<int> myList = new List<int>();
        List<Command> undo = new List<Command>();
        List<Command> redo = new List<Command>();
        string cmdList = @"1. 추가(뒤)    2. 삭제(뒤)
3. 추가(앞)    4. 삭제(앞)
6. 되돌리기    7. 다시실행
8. 저장        9. 로드
0. 끝";


        while (true)
        {
            do
            {
                Console.Clear();
                Console.WriteLine(cmdList);
                Console.WriteLine("\nList :");
                foreach (int i in myList)
                    Console.Write($"{i} ");
                Console.Write("\n\n명령을 입력해주세요 : ");
                int[] cusorPos = { Console.CursorLeft, Console.CursorTop };

                Console.WriteLine("\n\n[History]");
                for (int i = 0; i < undo.Count; i++)
                {
                    Console.Write(undo[i]);
                    if (i == undo.Count - 1)
                        Console.Write(" <<");
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                for (int i = 0; i < redo.Count; i++)
                {
                    Console.WriteLine(redo[i]);
                }
                Console.ResetColor();

                Console.CursorLeft = cusorPos[0];
                Console.CursorTop = cusorPos[1];
            } while (!int.TryParse(Console.ReadLine(), out select) || !function.Contains(select));

            switch (select)
            {
                case 0:
                    return;
                case 1: /////////////////////////////////////////////////// 추가 (뒤)
                    Console.Write("추가할 숫자를 입력해주세요 : ");
                    if (int.TryParse(Console.ReadLine(), out num))
                    {
                        var cmd = new CmdPushBack() { List = myList, Number = num };
                        cmd.Do();
                        undo.Add(cmd);
                    }
                    break;
                case 2: /////////////////////////////////////////////////// 삭제 (뒤)
                    if (myList.Count > 0)
                    {
                        var cmd = new CmdPopBack() { List = myList };
                        cmd.Do();
                        undo.Add(cmd);
                    }
                    break;
                case 3: /////////////////////////////////////////////////// 추가 (앞)
                    Console.Write("추가할 위치와 숫자를 입력해주세요 : ");
                    if (int.TryParse(Console.ReadLine(), out num))
                    {
                        var cmd = new CmdPushFront() { List = myList, Number = num };
                        cmd.Do();
                        undo.Add(cmd);
                    }
                    break;
                case 4: /////////////////////////////////////////////////// 삭제 (앞)
                    if (myList.Count > 0)
                    {
                        var cmd = new CmdPopFront() { List = myList };
                        cmd.Do();
                        undo.Add(cmd);
                    }
                    break;
                case 6: /////////////////////////////////////////////////// 되돌리기
                    if (undo.Count > 0)
                    {
                        var cmd = undo[undo.Count - 1];
                        cmd.Undo();
                        undo.RemoveAt(undo.Count - 1);
                        redo.Insert(0, cmd);
                    }
                    break;
                case 7: /////////////////////////////////////////////////// 다시실행
                    if (redo.Count > 0)
                    {
                        var cmd = redo[0];
                        cmd.Do();
                        redo.RemoveAt(0);
                        undo.Add(cmd);
                    }
                    break;
                case 8: /////////////////////////////////////////////////// 저장
                    using (FileStream fs = File.Create(@".\list.txt"))
                    using (TextWriter tw = new StreamWriter(fs))
                    {
                        //무명형식을 만들고 직렬화
                        var save = new { List = myList, Undo = undo, Redo = redo };
                        
                        var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };
                        tw.WriteLine(JsonConvert.SerializeObject(save, Formatting.Indented, settings));
                        
                    }
                    break;
                case 9: /////////////////////////////////////////////////// 로드
                    undo.Clear();
                    redo.Clear();
                    myList.Clear();
                    using (FileStream fs = File.OpenRead(@".\list.txt"))
                    using (TextReader br = new StreamReader(fs))
                    {
                        //무명형식으로 역직렬화 하기 위한 정의
                        var saveDef = new { List = new List<int>(), Undo = new List<Command>(), Redo = new List<Command>() };
                        
                        //역직렬화
                        var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };
                        var save = JsonConvert.DeserializeAnonymousType(br.ReadToEnd(), saveDef, settings);
                        
                        
                        myList = save.List;
                        undo = save.Undo;
                        redo = save.Redo;

                        foreach(var c in undo)
                        {
                            c.List = myList;
                        }

                        foreach(var c in redo)
                        {
                            c.List = myList;
                        }
                    }
                    break;
            }
        }
    }

    #region MYLIST_TEST_FUNC
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
    #endregion
}
