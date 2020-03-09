using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController 
{
    private Queue<KnifeView> _knifeViewsToScene;
    private KnifeView _currentKnife;
    private readonly KnifePool _knifePool;
    private readonly KnifeFactory _knifeFactory;

    public KnifeController (KnifeFactory knifeFactory)
    {
        _knifeViewsToScene = new Queue<KnifeView>();
        _knifePool = new KnifePool(knifeFactory);
    }
    public void Start()
    {
        GetKnifies(10);
        SetNextKnife();
        Debug.Log(_knifeViewsToScene.Count);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _currentKnife.IsReadyToFly = !_currentKnife.IsReadyToFly;
        if (_currentKnife.IsReadyToFly)
        {
            _currentKnife.Move();
            SetNextKnife();
        }
    }

    private void GetKnifies (int count)
    {
        for (int i = 0; i < count; i++)
        {
            _knifeViewsToScene.Enqueue(_knifePool.GetObject());
        }
    }

    private void SetNextKnife()
    {
        _currentKnife = _knifeViewsToScene.Dequeue();
    }
        
}
