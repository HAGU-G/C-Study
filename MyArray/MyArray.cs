using System.Collections;
using System.Diagnostics;
using System.Net.Http.Headers;

public class MyArray
{
    public static void Reverse<T>(T[] array)
    {
        for (int i = 0; i < array.Length / 2; i++)
        {
            (array[i], array[^(i + 1)]) = (array[^(i + 1)], array[i]);
        }
    }

    public static void Reverse<T>(T[] array, int index, int length)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(length);
        try
        {
            int lastIndex = index + length - 1;
            for (int i = 0; i < length / 2; i++)
            {
                (array[index + i], array[lastIndex - i]) = (array[lastIndex - i], array[index + i]);
            }
        }
        catch
        {
            throw new ArgumentException("Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
        }
    }

    public static void Fill<T>(T[] array, T value, int startIndex, int count)
    {
        for (int i = 0; i < count; i++)
        {
            array[startIndex + i] = value;
        }
    }

    public static void Copy<T>(T[] sourceArray, T[] destinationArray, int length)
    {
        for (int i = 0; i < length; i++)
        {
            destinationArray[i] = sourceArray[i];
        }
    }

    public static void Resize<T>(ref T[] array, int newSize)
    {
        T[] temp = new T[newSize];
        for (int i = 0; i < Math.Min(array.Length, newSize); i++)
        {
            temp[i] = array[i];
        }
        array = temp;
    }

    public static void Clear<T>(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = default(T);
        }
    }

    public static void Clear<T>(T[] array, int index, int length)
    {
        for (int i = 0; i < length; ++i)
        {
            array[index + i] = default(T);
        }
    }

    public static void Sort<T>(T[] array) where T : IComparable<T>
    {
        if (array.Length <= 1)
        {
            return;
        }

        Stopwatch timeCheck = new Stopwatch();
        timeCheck.Start();
        for (int i = array.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                if (array[j].CompareTo(array[j + 1]) > 0)
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
        timeCheck.Stop();
        Console.WriteLine($"정렬 시간(ns) {timeCheck.ElapsedTicks}");

    }

    public static void InsertionSort<T>(T[] array) where T : IComparable<T>
    {
        if (array.Length <= 1)
        {
            return;
        }

        Stopwatch timeCheck = new Stopwatch();
        timeCheck.Start();
        for (int i = 1; i < array.Length; i++)
        {
            for (int j = i; j >= 1; j--)
            {
                if (array[j].CompareTo(array[j - 1]) < 0)
                {
                    (array[j], array[j - 1]) = (array[j - 1], array[j]);
                }
                else
                {
                    break;
                }
            }
        }
        timeCheck.Stop();
        Console.WriteLine($"정렬 시간(ns) {timeCheck.ElapsedTicks}");
    }

    public static void SelectionSort<T>(T[] array) where T : IComparable<T>
    {
        if (array.Length <= 1)
        {
            return;
        }
        Stopwatch timeCheck = new Stopwatch();
        timeCheck.Start();
        for (int i = 0; i < array.Length; i++)
        {
            int min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j].CompareTo(array[min]) < 0)
                {
                    min = j;
                }
            }
            (array[i], array[min]) = (array[min], array[i]);
        }
        timeCheck.Stop();
        Console.WriteLine($"정렬 시간(ns) {timeCheck.ElapsedTicks}");

    }

    public static int IndexOf<T>(T[] array, T value) where T : IEquatable<T>
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Equals(value))
            {
                return i;
            }
        }
        return -1;
    }

    public static int BinarySearch<T>(T[] array, T value) where T : IEquatable<T>, IComparable<T>
    {
        int start = 0;
        int end = array.Length - 1;

        while (start <= end)
        {
            int middle = (start + end) / 2;
            if (array[middle].Equals(value))
            {
                return middle;
            }
            else if (array[middle].CompareTo(value) < 0)
            {
                start = middle + 1;
            }
            else
            {
                end = middle - 1;
            }
        }
        return -1;
    }

    public static void ForEach<T>(T[] array, Action<T> action)
    {
        foreach (T item in array)
        {
            action(item);
        }
    }

    public static bool Exists<T>(T[] array, Predicate<T> match)
    {
        foreach (T item in array)
        {
            if (match(item))
                return true;
        }
        return false;
    }
    public static void Sort<T>(T[] array, Comparison<T> comparison)
    {
        //버블 정렬
        //if (array.Length <= 1)
        //{
        //    return;
        //}

        //Stopwatch timeCheck = new Stopwatch();
        //timeCheck.Start();
        //for (int i = array.Length - 1; i >= 0; i--)
        //{
        //    for (int j = 0; j < i; j++)
        //    {
        //        if (comparison(array[j], array[j + 1]) > 0)
        //        {
        //            (array[j], array[j + 1]) = (array[j + 1], array[j]);
        //        }
        //    }
        //}
        //timeCheck.Stop();
        //Console.WriteLine($"정렬 시간(ns) {timeCheck.ElapsedTicks}");

        //삽입정렬
        if (array.Length <= 1)
        {
            return;
        }
        Stopwatch timeCheck = new Stopwatch();
        timeCheck.Start();
        for (int i = 0; i < array.Length; i++)
        {
            int min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (comparison(array[j], array[j - 1]) < 0)
                {
                    min = j;
                }
            }
            (array[i], array[min]) = (array[min], array[i]);
        }
        timeCheck.Stop();
        Console.WriteLine($"정렬 시간(ns) {timeCheck.ElapsedTicks}");
    }

    public static T? Find<T>(T[] array, Predicate<T> match)
    {
        foreach (T item in array)
        {
            if (match(item))
                return item;
        }
        return default;
    }

    public static T[] FindAll<T>(T[] array, Predicate<T> match)
    {
        List<T> temp = new List<T>();
        foreach (T item in array)
        {
            if (match(item))
            {
                temp.Add(item);
            }
        }
        return temp.ToArray();
    }

    public static int FindIndex<T>(T[] array, Predicate<T> match)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (match(array[i]))
                return i;
        }
        return -1;
    }

    public static T? FindLast<T>(T[] array, Predicate<T> match)
    {
        for (int i = array.Length-1; i >=0; i--)
        {
            if (match(array[i]))
                return array[i];
        }
        return default;
    }
    public static int FindLastIndex<T>(T[] array, Predicate<T> match)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (match(array[i]))
                return i;
        }
        return -1;
    }
}