using System.Collections.Generic;
using UnityEngine;

public class KnifeController 
{
	private const int CountKnifiesOnLevel = 10;
	private const int LeftMouseButton = 0;
	private int indexCurrentKnife;
    private List<KnifeView> _knifeViewsToScene;
    private KnifeView _currentKnife;
    private readonly Pool<KnifeView> _knifePool;
    private readonly KnifeFactory _knifeFactory;

    public KnifeController (KnifeFactory knifeFactory)
    {
        _knifeViewsToScene = new List<KnifeView>();
        _knifePool = new Pool<KnifeView>(knifeFactory);
    }
    public void Start()
    {
        GetKnifies(CountKnifiesOnLevel);
        SetNextKnife();
        Subscribe();
		indexCurrentKnife = 0;

    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
            _currentKnife.IsReadyToMove = true;
        if (_currentKnife.IsReadyToMove)      
            SetNextKnife();
		MoveAllKnifies();
	}

    private void GetKnifies (int count)
    {
        for (int i = 0; i < count; i++)
        {
			_knifeViewsToScene.Add(_knifePool.GetObject());
        }
    }

    private void SetNextKnife()
    {
		if (indexCurrentKnife >= _knifeViewsToScene.Count) return;		
		_currentKnife = _knifeViewsToScene[indexCurrentKnife];
		indexCurrentKnife++;
	}
    
	private void MoveAllKnifies()
	{
		foreach (var knife in _knifeViewsToScene)
		{
			if (knife.IsReadyToMove)
				knife.Move();
		}
	}

    private void Hit()
    {
        _knifeViewsToScene[indexCurrentKnife - 1].transform.SetParent(_knifeViewsToScene[indexCurrentKnife - 1].transform);
        _knifeViewsToScene[indexCurrentKnife - 1].IsReadyToMove = false;
    }

    private void Subscribe()
    {
    	foreach (var knife in _knifeViewsToScene)
        {
            knife.OnTargetCicleCollision += Hit;
        }
    }
}
