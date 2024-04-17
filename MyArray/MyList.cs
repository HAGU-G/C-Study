using System.Collections;
using System.Dynamic;

internal class MyList<T> : IEnumerable<T>
{
    private T[] items;
    private int capacity;
    public int Capacity
    {
        get => capacity;
        set
        {
            capacity = value;
            T[] temp = new T[value];
            items.CopyTo(temp, 0);
            items = temp;
        }
    }

    public int Count { get; private set; }
    public T this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }

    public MyList(int capacity = 0)
    {
        this.capacity = capacity;
        items = new T[this.capacity];
        Count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        for (int i = 0; i <= Count; i++)
        {
            int index = i;
            yield return items[index];
        }
    }

    public void Add(T item)
    {
        if (Count >= capacity)
            Capacity += Capacity / 2 + 1;

        items[Count++] = item;
    }
}