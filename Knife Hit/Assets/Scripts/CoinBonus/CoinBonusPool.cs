using System.Collections.Generic;
using UnityEngine;

public class CoinBonusPool : MonoBehaviour
{
    private CoinBonusFactory _coinBonusFactory;
    public Queue<CoinBonusView> PoolQueue = new Queue<CoinBonusView>();

    public CoinBonusPool(CoinBonusFactory coinBonusFactory)
    {
        _coinBonusFactory = coinBonusFactory;
    }

    public CoinBonusView GetObject()
    {
        if (PoolQueue.Count > 0)
            return PoolQueue.Dequeue();
        return _coinBonusFactory.Create();
    }

    public void Back(CoinBonusView targetCicle)
    {
        PoolQueue.Enqueue(targetCicle);
    }
}
