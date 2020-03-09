using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController 
{
    private readonly KnifeView _knifeView;
    private readonly KnifePool _knifePool;
    private readonly KnifeFactory _knifeFactory;

    public KnifeController (KnifeFactory knifeFactory)
    {
        _knifePool = new KnifePool(knifeFactory);
        _knifeView = _knifePool.GetObject();
    }
    public void Start()
    {
        
    }


    public void Update()
    {
        _knifeView.Move();
    }
}
