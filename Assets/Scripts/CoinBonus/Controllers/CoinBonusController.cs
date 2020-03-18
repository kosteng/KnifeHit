using System.Collections.Generic;
public class CoinBonusController
{
    private readonly CoinBonusView _coinBonusView;
    private readonly CoinBonusFactory _coinBonusFactory;
    private readonly Pool<CoinBonusView> _coinBonusPool;
    private List<CoinBonusView> _coinBonusViewsToScene;
    public CoinBonusController(CoinBonusFactory coinBonusFactory)
    {
        _coinBonusPool = new Pool<CoinBonusView>(coinBonusFactory);
        _coinBonusView = _coinBonusPool.GetObject();
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

    private void Subscribe()
    {
        foreach (var coinBonus in _coinBonusViewsToScene)
        {
            coinBonus.OnCoinBonusByKnifeCollision += CoinBonusByKnifeCollision;
        }
    }

    private void CoinBonusByKnifeCollision()
    {

    }
}
