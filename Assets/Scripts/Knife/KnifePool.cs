using System.Collections.Generic;

public class KnifePool<T>
{
    private IFactory<T> _knifeFactory;
    public Queue<T> PoolQueue = new Queue<T>();

    public KnifePool(IFactory<T> knifeFactory)
    {
        _knifeFactory = knifeFactory;
    }

    public T GetObject()
    {
        if (PoolQueue.Count > 0)
            return PoolQueue.Dequeue();
        return _knifeFactory.Create();
    }

    public void Back(T knife)
    {
        PoolQueue.Enqueue(knife);
    }
}

