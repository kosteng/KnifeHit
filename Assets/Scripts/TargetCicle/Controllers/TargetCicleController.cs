using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCicleController 
{
    private readonly TargetCicleView _targetCicleView;
    private readonly TargetCiclePool _targetCiclePool;
    private TargetCicleFactory _cicleFactory;
    private float _speedRotation = 30;

    public TargetCicleController (TargetCicleFactory _cicleFactory)
    {
        _targetCiclePool = new TargetCiclePool(_cicleFactory);
        _targetCicleView = _targetCiclePool.GetObject();     
    }
    public void Start()
    {

    }

    public void Update()
    {
        _targetCicleView.Rotate(_speedRotation);
    }
}
