using UnityEngine;

public class KnifeFactory : MonoBehaviour, IFactory<KnifeView>
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private KnifeView _knifePrefab;
    private Vector2 _startPosition = new Vector2(0f, -7f);

    public KnifeView Create()
    {
        var knife = Instantiate(_knifePrefab, _startPosition, Quaternion.identity);
        SetParent(knife);
        knife.gameObject.SetActive(false);

        return knife;
    }

    private void SetParent(KnifeView child)
    {
        child.transform.SetParent(_parent.transform);
    }
}
