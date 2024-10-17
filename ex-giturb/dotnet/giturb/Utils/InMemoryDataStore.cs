using System.Collections;

public interface IDataStore<T> : IEnumerable<T>
{
    void Clear();
    void Add(T item);
}

public class InMemoryDataStore<T> : IDataStore<T>
    where T : class
{
    private readonly List<T> data = new();

    public InMemoryDataStore()
    {
    }

    public InMemoryDataStore(IEnumerable<T> seededData)
    {
        data.AddRange(seededData);
    }

    public void Add(T item)
    {
        data.Add(item);
    }

    public void Clear()
    {
        data.Clear();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}