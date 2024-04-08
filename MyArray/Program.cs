
using System.ComponentModel;

public class MyClass : IComparable<MyClass>, IEquatable<MyClass>
{
    public int a;
    public MyClass(int num = 0) { a = num; }

    public int CompareTo(MyClass? obj)
    {
        return a - obj.a;
    }

    bool IEquatable<MyClass>.Equals(MyClass? other)
    {
        return a == other?.a;
    }

    public override string? ToString()
    {
        return a.ToString();
    }
}


internal class Program
{

    static void WriteArray<T>(T[] array)
    {
        foreach (T i in array)
        {
            Console.Write($"{i?.ToString()} ");
        }
        Console.WriteLine();
    }
    static void Main(string[] args)
    {
        //int, float, 사용자 정의 클래스, string 확인 완료
        Random r = new Random();
        MyClass[] array = new MyClass[30];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = new MyClass(r.Next(-100, 101));
        }
        MyClass[] myArray = (MyClass[])array.Clone();
        MyClass[] srcArray = { new MyClass(1), new MyClass(2), new MyClass(3), new MyClass(4) };
        WriteArray(array);
        WriteArray(myArray);

        Console.WriteLine($"\nIndexOf(array, 3)");
        Console.WriteLine(Array.IndexOf(array, new MyClass(3)));
        Console.WriteLine(MyArray.IndexOf(myArray, new MyClass(3)));

        Console.WriteLine($"\nSort(array)");
        Array.Sort(array);
        //MyArray.Sort(myArray);
        //MyArray.SelectionSort(myArray);
        MyArray.InsertionSort(myArray);
        WriteArray(array);
        WriteArray(myArray);

        Console.WriteLine($"\nBinarySearch(array, 3)");
        Console.WriteLine(Array.BinarySearch(array, new MyClass(3)));
        Console.WriteLine(MyArray.BinarySearch(myArray, new MyClass(3)));

        Console.WriteLine($"\nReverse(array)");
        Array.Reverse(array);
        MyArray.Reverse(myArray);
        WriteArray(array);
        WriteArray(myArray);

        Console.WriteLine($"\nReverse(array, 2, 3)");
        Array.Reverse(array, 2, 3);
        MyArray.Reverse(myArray, 2, 3);
        WriteArray(array);
        WriteArray(myArray);

        Console.WriteLine($"\nFill(array, 100, 3, 1)");
        Array.Fill(array, new MyClass(100), 3, 1);
        MyArray.Fill(myArray, new MyClass(100), 3, 1);
        WriteArray(array);
        WriteArray(myArray);

        Console.WriteLine($"\nCopy(srcArray, array, srcArray.Length)");
        Array.Copy(srcArray, array, srcArray.Length);
        MyArray.Copy(srcArray, myArray, srcArray.Length);
        WriteArray(srcArray);
        WriteArray(array);
        WriteArray(myArray);

        Console.WriteLine($"\nResize(ref array, 10)");
        Array.Resize(ref array, 10);
        MyArray.Resize(ref myArray, 10);
        WriteArray(array);
        WriteArray(myArray);

        Console.WriteLine($"\nClear(array, 2, 2)");
        Array.Clear(array, 2, 2);
        MyArray.Clear(myArray, 2, 2);
        WriteArray(array);
        WriteArray(myArray);

        Console.WriteLine($"\nClear(array)");
        Array.Clear(array);
        MyArray.Clear(myArray);
        WriteArray(array);
        WriteArray(myArray);

        Console.WriteLine($"\nForEach(array, Lambda)");
        int[] newArray = { 1, 2, 3, 4, 5, 6, 6, 6, 5, 6 };
        MyArray.ForEach(newArray, item => { Console.Write(item *= -1); });
        MyArray.ForEach(newArray, Console.Write);
        Console.WriteLine();

        Console.WriteLine($"\nExists(array, Predicate)");
        string[] planets = { "Mercury", "Venus",
                "Earth", "Mars", "Jupiter",
                "Saturn", "Uranus", "Neptune" };
        Console.WriteLine("One or more planets begin with 'M': {0}",
            MyArray.Exists(planets, element => element.StartsWith("M")));
        Console.WriteLine("One or more planets begin with 'T': {0}",
            MyArray.Exists(planets, element => element.StartsWith("T")));
        Console.WriteLine("Is Pluto one of the planets? {0}",
            MyArray.Exists(planets, element => element == "Pluto"));
        Console.WriteLine("Is Uranus one of the planets? {0}",
            MyArray.Exists(planets, element => element == "Uranus"));

        Console.WriteLine($"\nSort(array, Comparison)");
        MyArray.Sort(planets, (item1, item2) => { return item1.CompareTo(item2); });
        WriteArray(planets);

        Console.WriteLine($"\nFind(array, Predicate)");
        Console.WriteLine("One or more planets begin with 'M': {0}",
            MyArray.Find(planets, element => element.StartsWith("M")));
        Console.WriteLine("One or more planets begin with 'T': {0}",
            MyArray.Find(planets, element => element.StartsWith("T")));
        Console.WriteLine("Is Pluto one of the planets? {0}",
            MyArray.Find(planets, element => element == "Pluto"));
        Console.WriteLine("Is Uranus one of the planets? {0}",
            MyArray.Find(planets, element => element == "Uranus"));
        Console.WriteLine("10 찾아! {0}",
            MyArray.Find(newArray, element => element == 10));

        Console.WriteLine($"\nFindAll(array, Predicate)");
        Console.Write("3의 배수! ");
        WriteArray(MyArray.FindAll(newArray, element => element % 3 == 0));

        Console.WriteLine($"\nFindLast(array, Predicate)");
        Console.Write("5 찾아 ");
        Console.WriteLine(MyArray.FindLast(newArray, element => element == 5));

        Console.WriteLine($"\nFindLastIndex(array, Predicate)");
        Console.Write("5 찾아 ");
        Console.WriteLine(MyArray.FindLastIndex(newArray, element => element == 5));


        Console.WriteLine("\nQuickSort(array, left, right, Comparison)");
        int[] quickArray = new int[21];
        for (int i = 0; i < quickArray.Length; i++)
        {
            quickArray[i] = r.Next(-100, 101);
        }

        WriteArray(quickArray);
        MyArray.QuickSort(quickArray, 0, quickArray.Length - 1, (i1, i2) => i1 - i2);
        WriteArray(quickArray);
    }
}