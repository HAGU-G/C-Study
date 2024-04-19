using System.Collections;

internal class MyList<T> : IEnumerable<T>
{
    private T[] items;
    private int capacity;
    public int Capacity
    {
        get => capacity;
        set
        {
            if (value < Count)
                throw new ArgumentOutOfRangeException();
            capacity = value;
            T[] temp = new T[value];
            items.CopyTo(temp, 0);
            items = temp;
        }
    }
    public int Count { get; private set; }
    public T this[int index]
    {
        get
        {
            IndexCheck(index);
            return items[index];
        }
        set
        {
            IndexCheck(index);
            items[index] = value;
        }
    }

    public MyList(int capacity = 0)
    {
        this.capacity = capacity;
        items = new T[this.capacity];
        Count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            //int index = i; //T형을 리턴하기 때문에 캡쳐되지 않는다.
            yield return items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void CapacityChange()
    {
        if (Count >= capacity)
            Capacity += Capacity / 2 + 1;
    }
    private void IndexCheck(int index)
    {
        if (index >= Count)
            throw new IndexOutOfRangeException();
    }

    public void Add(T item)
    {
        CapacityChange();
        items[Count++] = item;
    }

    public void Insert(int index, T item)
    {
        IndexCheck(index);
        CapacityChange();
        items[Count++] = item;
        for (int i = Count - 1; i > index; i--)
        {
            (items[i], items[i - 1]) = (items[i - 1], items[i]);
        }
    }

    public void Clear()
    {
        Count = 0;
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = default;
        }
    }

    public bool Remove(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (items[i].Equals(item))
            {
                RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public void RemoveAt(int index)
    {
        IndexCheck(index);
        items[index] = default;
        if (index == Count - 1)
        {
            Count--;
            return;
        }

        for (int i = index; i < Count-1; i++)
        {
            (items[i], items[i + 1]) = (items[i + 1], items[i]);
        }
        Count--;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (items[i].Equals(item))
            {
                return true;
            }
        }
        return false;
    }
}