using System.Collections.Generic;

public class TargetCiclePool
{
    private TargetCicleFactory _targetCicleFactory;
    public Queue<TargetCicleView> PoolQueue = new Queue<TargetCicleView>();

    public TargetCiclePool(TargetCicleFactory targetCicleFactory)
    {
        _targetCicleFactory = targetCicleFactory;
    }

    public TargetCicleView GetObject()
    {
        if (PoolQueue.Count > 0)       
            return PoolQueue.Dequeue();
        return _targetCicleFactory.Create();      
   }

    public void Back(TargetCicleView targetCicle)
    {
        PoolQueue.Enqueue(targetCicle);
    }
}
