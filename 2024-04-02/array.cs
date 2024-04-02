class Program
{
    static void FuncRef(ref int num)
    {
        num = 2;
    }

    static void FuncOut(int num, out int outNum)
    {
        outNum = num;
        num = 4;
    }

    static void FuncName(int a, int b, int c)
    {
    }

    public static void Main()
    {
        int a = 3;
        int b;
        FuncRef(ref a); //a는 2가 된다.
        FuncOut(a, out b); //out int c 처럼 변수를 선언할 수 있다.
        Console.WriteLine(a);
        Console.WriteLine(b);

        FuncName(a:2, 1, 2);
    }
}