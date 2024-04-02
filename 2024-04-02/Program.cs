///////////////// 반복문 문제 /////////////////
//1. 직각삼각형
for (int i = 0; i < 5; i++)
{
    for (int j = 0; j <= i; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}


//2. 역직각삼각형
Console.WriteLine();
for (int i = 5; i > 0; i--)
{
    for (int j = 0; j < i; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}


//3. 1번을 while문으로
{
    Console.WriteLine();
    int i = 0;
    while (i < 5)
    {
        int j = 0;
        while (j <= i)
        {
            Console.Write("*");
            j++;
        }
        i++;
        Console.WriteLine();
    }
}

//3. 1번을 while문으로
{
    Console.WriteLine();
    int i = 5;
    do
    {

        int j = 0;
        while (j < i)
        {
            Console.Write("*");
            j++;
        }
        i--;
        Console.WriteLine();
    } while (i > 0);
}


//4. 사용자 입력을 받아 직각삼각형 출력
Console.Write("\n반복 횟수를 입력하세요 : ");
int inputNum = int.Parse(Console.ReadLine());
if (inputNum <= 0)
{
    Console.WriteLine("0보다 작거나 같은 수는 입력할 수 없습니다.");
    return;
}

for (int i = 0; i < inputNum; i++)
{
    for (int j = 0; j <= i; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}







///////////////// 스위치 문제 /////////////////
Console.WriteLine("\n\n///////////////// 스위치 문제 /////////////////");
//1. 여러 타입의 숫자(int, float, double, decimal)의 합을 구한다.
object[] numbers = { 1, 2.5f, 3.0, 4.5m };
double sum = 0;

foreach (object num in numbers)
{
    sum += num switch
    {
        int i => i,
        float f => f,
        double d => d,
        decimal m => (double)m
    }; ;
}
Console.WriteLine($"The sum is {sum}.");


//2. 사용자로부터 문자열 또는 숫자를 입력받아, 문자열이면 그 길이를, 숫자면 그 제곱을 출력한다.
Console.WriteLine();
Console.WriteLine("Enter a string or a number:");
string input = Console.ReadLine();
object x;

if (int.TryParse(input, out int intValue))
{
    x = intValue;
}
else if (double.TryParse(input, out double doubleValue))
{
    x = doubleValue;
}
else
{
    x = input;
}

var result = x switch
{
    string s => s.Length,
    int i => i * i,
    double f => f * f
};
Console.WriteLine(result);


//3. 사용자로부터 DateTime 객체를 입력받아, 그 날짜가 미래인지 과거인지, 또는 오늘인지 판별하는 프로그램을 작성하라.
Console.WriteLine();
Console.WriteLine("Enter a date in the format YYYY-MM-DD:");
input = Console.ReadLine();
DateTime dt;
if (DateTime.TryParse(input, out dt))
{
    string dateStatus = dt switch
    {
        _ when dt.CompareTo(DateTime.Today) > 0 => "미래",
        _ when dt.CompareTo(DateTime.Today) == 0 => "오늘",
        _ => "과거"
    };
    Console.WriteLine(dateStatus);
}
else
{
    Console.WriteLine("Invalid date format.");
}