//사용자에게 문자열을 입력받고 문자열 출력하기
//1. 입력 받은 문자열을 뒤집어서 출력
//2. 입력 받은 문자열의 단어의 수를 출력
//3. 입력 받은 문자열에서 알파벳, 특수문자, 숫자 갯수를 출력하라
//4. 입력 받은 문자열에서 가장 많은 문자를 찾아라.
//5. 입력 받은 문자열의 대소문자를 바꿔서 출력해라.
//6. 문자열 2개를 입력 받아서 첫번째 문자열에 두번째 문자열이 몇 번 등장하는지 출력해라.

class Program
{
    public static void Main()
    {
        Console.Write("첫 번째 문자열 입력 : ");
        string input = Console.ReadLine();

        //1. 입력 받은 문자열을 뒤집어서 출력
        Console.WriteLine();
        Console.Write("거꾸로 : ");
        Console.WriteLine(input.Reverse().ToArray());
        
        //2. 입력 받은 문자열의 단어의 수를 출력
        Console.WriteLine();
        Console.Write("단어의 수 : ");
        Console.WriteLine(input.Split().Length);

        //3. 입력 받은 문자열에서 알파벳, 특수문자, 숫자 갯수를 출력하라
        int countASCLetter = 0;
        int countNum = 0;
        int countLetterAndNum = 0;
        foreach (char c in input)
        {
            if (char.IsAsciiLetter(c))
                countASCLetter++;
            else if (char.IsNumber(c))
                countNum++;
            if (char.IsLetterOrDigit(c))
                countLetterAndNum++;
            //char.IsSymbol(c);
        }
        Console.WriteLine();
        Console.WriteLine($"알파뱃 : {countASCLetter}, 특수문자 : {input.Length - countLetterAndNum}, 숫자 : {countNum}");

        //4. 입력 받은 문자열에서 가장 많은 문자를 찾아라.
        char maxChar = '\0';
        int maxCount = 0;
        foreach (char c1 in input)
        {
            int tempCount = 0;
            foreach (char c2 in input)
            {
                if (c1 == c2)
                {
                    tempCount++;
                }
            }
            if (tempCount > maxCount)
            {
                maxCount = tempCount;
                maxChar = c1;
            }
        }
        Console.WriteLine();
        Console.WriteLine($"{maxChar}이(가) {maxCount}개로 가장 많습니다.");

        //5. 입력 받은 문자열의 대소문자를 바꿔서 출력해라.
        Console.WriteLine();
        Console.WriteLine("대소문자 변경하여 출력");
        foreach (char c in input)
        {
            Console.Write(char.IsLower(c) ? char.ToUpper(c) : char.ToLower(c));
        }
        Console.WriteLine();

        //6. 문자열 2개를 입력 받아서 첫번째 문자열에 두번째 문자열이 몇 번 등장하는지 출력해라.
        Console.WriteLine();
        Console.Write("두 번째 문자열 입력 : ");
        Console.WriteLine("첫번째 문자열에 두번째 문자열이 {0}번 등장합니다.", input.Split(Console.ReadLine()).Length - 1);
        //Console.WriteLine($"첫번째 문자열에 두번째 문자열이 {input.Split(Console.ReadLine()).Length - 1}번 등장합니다.");
        //Console.WriteLine(string.Format("첫번째 문자열에 두번째 문자열이 {0}번 등장합니다.", input.Split(Console.ReadLine()).Length - 1));
        //index = 0;
        //int countStr = 0;
        //while (index != -1)
        //{
        //    index = input.IndexOf(inputSecond, index + 1);
        //    if (index != -1)
        //        countStr++;
        //    else if (index+1 >= input.Length)
        //        break;
        //}
        //Console.WriteLine(countStr);
    }
}

