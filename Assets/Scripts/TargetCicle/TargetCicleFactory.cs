using UnityEngine;

public class TargetCicleFactory : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private TargetCicleView _targetCiclePrefab;

    public TargetCicleView Create()
    {
        var targetCicle = Instantiate(_targetCiclePrefab, Vector2.zero, Quaternion.identity);
        SetParent(targetCicle);
        return targetCicle;
    }

    private void SetParent(TargetCicleView child)
    {
        child.transform.SetParent(_parent.transform);
    }
}
