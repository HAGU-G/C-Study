﻿public class MyArray
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
        for (int i = 0; i < (array.Length < newSize ? array.Length : newSize); i++)
        {
            temp[i] = array[i];
        }
        array = temp;
    }

    public static void Clear(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = 0;
        }
    }

    public static void Clear(int[] array, int index, int length)
    {
        for (int i = 0; i < length; ++i)
        {
            array[index + i] = 0;
        }
    }

    public static void Sort(int[] array)
    {
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