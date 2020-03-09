using UnityEngine;

public class KnifeFactory : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private KnifeView _knifePrefab;
    private Vector2 _startPosition = new Vector2(0f, -4f);

    public KnifeView Create()
    {
        var knife = Instantiate(_knifePrefab, _startPosition, Quaternion.identity);
        SetParent(knife);
        return knife;
    }

    private void SetParent(KnifeView child)
    {
        child.transform.SetParent(_parent.transform);
    }
}
