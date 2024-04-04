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
        for(int i = 0; i< array.Length; i++)
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

        Array.Sort(array);
        //MyArray.Sort(myArray);
        //MyArray.SelectionSort(myArray);
        MyArray.InsertionSort(myArray);
        Console.WriteLine($"\nSort(array)");
        WriteArray(array);
        WriteArray(myArray);

        Console.WriteLine($"\nBinarySearch(array, 3)");
        Console.WriteLine(Array.BinarySearch(array, new MyClass(3)));
        Console.WriteLine(MyArray.BinarySearch(myArray, new MyClass(3)));

        Array.Reverse(array);
        MyArray.Reverse(myArray);
        Console.WriteLine($"\nReverse(array)");
        WriteArray(array);
        WriteArray(myArray);

        Array.Reverse(array, 2, 3);
        MyArray.Reverse(myArray, 2, 3);
        Console.WriteLine($"\nReverse(array, 2, 3)");
        WriteArray(array);
        WriteArray(myArray);

        Array.Fill(array, new MyClass(100), 3, 1);
        MyArray.Fill(myArray, new MyClass(100), 3, 1);
        Console.WriteLine($"\nFill(array, 100, 3, 1)");
        WriteArray(array);
        WriteArray(myArray);

        Array.Copy(srcArray, array, srcArray.Length);
        MyArray.Copy(srcArray, myArray, srcArray.Length);
        Console.WriteLine($"\nCopy(srcArray, array, srcArray.Length)");
        WriteArray(srcArray);
        WriteArray(array);
        WriteArray(myArray);

        Array.Resize(ref array, 10);
        MyArray.Resize(ref myArray, 10);
        Console.WriteLine($"\nResize(ref array, 10)");
        WriteArray(array);
        WriteArray(myArray);

        Array.Clear(array, 2, 2);
        MyArray.Clear(myArray, 2, 2);
        Console.WriteLine($"\nClear(array, 2, 2)");
        WriteArray(array);
        WriteArray(myArray);

        Array.Clear(array);
        MyArray.Clear(myArray);
        Console.WriteLine($"\nClear(array)");
        WriteArray(array);
        WriteArray(myArray);
    }
}