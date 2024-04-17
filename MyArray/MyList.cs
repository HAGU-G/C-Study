using System.Collections;

internal class MyList<T> : IEnumerable<T>
{
    private T[] item;
    private int capacity;
    public int Capacity
    {
        get => capacity;
        set
        {
            capacity = value;
            T[] temp = new T[value];
            item.CopyTo(temp, 0);
            item = temp;
        }
    }

    public int Count { get; }
    private int front;
    private int back;
    public T this[int index] { get => item[index]; set => item[index] = value; }

    public MyList(int capacity = 10)
    {
        this.capacity = capacity;
        item = new T[this.capacity];
        
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}