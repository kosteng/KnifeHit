
using UnityEngine;

public class CoinBonusFactory : MonoBehaviour, IFactory<CoinBonusView>
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private CoinBonusView _coinBonusPrefab;
    private Vector2 _startPosition = new Vector2(0f, -4f);

    public CoinBonusView Create()
    {
        var coinBonus = Instantiate(_coinBonusPrefab, Vector2.zero, Quaternion.identity);
        SetParent(coinBonus);
        return coinBonus;
    }

    private void SetParent(CoinBonusView child)
    {
        child.transform.SetParent(_parent.transform);
    }
}
