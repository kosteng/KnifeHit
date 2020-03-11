using System.Collections.Generic;
using UnityEngine;

public class KnifeController 
{
	private const int CountKnifiesOnLevel = 10;
	private const int LeftMouseButton = 0;
	private int indexCurrentKnife;
	private int indexKnifeHit;
	private bool isEmptyKnifies;
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
        indexCurrentKnife = 0;
		indexKnifeHit = 0;
		isEmptyKnifies = false;
		GetKnifies(CountKnifiesOnLevel);
        SetNextKnife();
        Subscribe();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton)&& !isEmptyKnifies)
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
		if (indexCurrentKnife >= _knifeViewsToScene.Count)
		{
			isEmptyKnifies = !isEmptyKnifies;
			return;
		}
		_currentKnife = _knifeViewsToScene[indexCurrentKnife];
        _currentKnife.gameObject.SetActive(true);
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
        _knifeViewsToScene[indexKnifeHit].transform.SetParent(_knifeViewsToScene[indexKnifeHit].CollisionObject.transform);
        _knifeViewsToScene[indexKnifeHit].IsReadyToMove = false;
		indexKnifeHit++;
	}

    private void Subscribe()
    {
    	foreach (var knife in _knifeViewsToScene)
        {
            knife.OnTargetCicleCollision += Hit;
        }
    }
}
