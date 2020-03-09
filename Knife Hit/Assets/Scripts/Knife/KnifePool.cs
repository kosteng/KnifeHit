using System.Collections.Generic;

public class KnifePool
{
    private KnifeFactory _knifeFactory;
    public Queue<KnifeView> PoolQueue = new Queue<KnifeView>();

    public KnifePool(KnifeFactory knifeFactory)
    {
        _knifeFactory = knifeFactory;
    }

    public KnifeView GetObject()
    {
        if (PoolQueue.Count > 0)
            return PoolQueue.Dequeue();
        return _knifeFactory.Create();
    }

    public void Back(KnifeView knife)
    {
        PoolQueue.Enqueue(knife);
    }
}

