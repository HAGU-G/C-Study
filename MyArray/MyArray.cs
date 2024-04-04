using System.Diagnostics;

public class MyArray
{
    public static void Reverse(int[] array)
    {
        for (int i = 0; i < array.Length / 2; i++)
        {
            (array[i], array[^(i + 1)]) = (array[^(i + 1)], array[i]);
        }
    }

    public static void Reverse(int[] array, int index, int length)
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

    public static void Fill(int[] array, int value, int startIndex, int count)
    {
        for (int i = 0; i < count; i++)
        {
            array[startIndex + i] = value;
        }
    }

    public static void Copy(int[] sourceArray, int[] destinationArray, int length)
    {
        for (int i = 0; i < length; i++)
        {
            destinationArray[i] = sourceArray[i];
        }
    }

    public static void Resize(ref int[] array, int newSize)
    {
        int[] temp = new int[newSize];
        for (int i = 0; i < Math.Min(array.Length, newSize); i++)
        {
            temp[i] = array[i];
        }
        array = temp;
    }

    public static void Clear(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = default;
        }
    }

    public static void Clear(int[] array, int index, int length)
    {
        for (int i = 0; i < length; ++i)
        {
            array[index + i] = default;
        }
    }

    public static void Sort(int[] array)
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
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
        timeCheck.Stop();
        Console.WriteLine($"정렬 시간(ns) {timeCheck.ElapsedTicks}");

    }

    public static void InsertionSort(int[] array)
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
                if (array[j] < array[j - 1])
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

    public static void SelectionSort(int[] array)
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
                if (array[j] < array[min])
                {
                    min = j;
                }
            }
            (array[i], array[min]) = (array[min], array[i]);
        }
        timeCheck.Stop();
        Console.WriteLine($"정렬 시간(ns) {timeCheck.ElapsedTicks}");

    }

    public static int IndexOf(int[] array, int value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return i;
            }
        }
        return -1;
    }

    public static int BinarySearch(int[] array, int value)
    {
        int start = 0;
        int end = array.Length - 1;

        while (start <= end)
        {
            int middle = (start + end) / 2;
            if (array[middle] == value)
            {
                return middle;
            }
            else if (array[middle] < value)
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

}