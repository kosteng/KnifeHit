public class CoinBonusController
{
    private readonly CoinBonusView _coinBonusView;
    private readonly CoinBonusFactory _coinBonusFactory;
    private readonly CoinBonusPool _coinBonusPool;

    public CoinBonusController(CoinBonusFactory coinBonusFactory)
    {
        _coinBonusPool = new CoinBonusPool(coinBonusFactory);
        _coinBonusView = _coinBonusPool.GetObject();
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }
}
