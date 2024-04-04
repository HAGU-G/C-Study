using System.Reflection;

internal class Program
{
    static void WriteArray(int[] array)
    {
        foreach (int i in array)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
    }
    static void Main(string[] args)
    {
        Random r = new Random();
        int[] array = new int[30];
        for(int i = 0; i< array.Length; i++)
        {
            array[i] = r.Next(-100, 101);
        }
        int[] myArray = (int[])array.Clone();
        WriteArray(array);
        WriteArray(myArray);
        Console.WriteLine($"\nIndexOf(array, 3)");
        Console.WriteLine(Array.IndexOf(array, 3));
        Console.WriteLine(MyArray.IndexOf(myArray, 3));

        Array.Sort(array);
        MyArray.SelectionSort(myArray);
        //MyArray.InsertionSort(myArray);
        Console.WriteLine($"\nSort(array)");
        WriteArray(array);
        WriteArray(myArray);

        Console.WriteLine($"\nBinarySearch(array, 3)");
        Console.WriteLine(Array.BinarySearch(array, 3));
        Console.WriteLine(MyArray.BinarySearch(myArray, 3));

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

        Array.Fill(array, 100, 3, 1);
        MyArray.Fill(myArray, 100, 3, 1);
        Console.WriteLine($"\nFill(array, 100, 3, 1)");
        WriteArray(array);
        WriteArray(myArray);

        int[] srcArray = { 1, 2, 3, 4 };
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
