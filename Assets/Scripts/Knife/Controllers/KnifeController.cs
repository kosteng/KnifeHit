using System.Collections.Generic;
using UnityEngine;

public class KnifeController 
{
	private const int CountKnifiesOnLevel = 10;
	private const int LeftMouseButton = 0;
	private int indexCurrentKnife;
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
		isEmptyKnifies = false;
		GetKnifies(CountKnifiesOnLevel);
        SetNextKnife();
        Subscribe();
    }

    public void Update()
    {
        if (_currentKnife.transform.position.y <= -4f)
            _currentKnife.MoveToStartPosition();
        if (Input.GetMouseButtonDown(LeftMouseButton) && !isEmptyKnifies)
        {
            _currentKnife.IsReadyToMove = true;
        }
        if (_currentKnife.IsReadyToMove)
            SetNextKnife();       
		MoveAllKnifies();
        knifekill();
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

    private void CollisionInTargetCicle(KnifeView knife, GameObject targetCicle)
    {
        knife.transform.SetParent(targetCicle.transform);
        knife.IsReadyToMove = false;
        knife.OnKnifeCollision -= HitKnifeByKnife;
    }

    private void Subscribe()
    {
    	foreach (var knife in _knifeViewsToScene)
        {
            knife.OnTargetCicleCollision += CollisionInTargetCicle;
            knife.OnKnifeCollision += HitKnifeByKnife;
            knife.OnCoinBonusCollision += CoinBonusCollision;
        }
    }

    private void knifekill()
    {
        for (int i = 0; i < _knifeViewsToScene.Count; i++)
        {
            if (_knifeViewsToScene[i].IsCollisionKnifeByKnife)
                _knifeViewsToScene[i].HitKnifeByKnifeMove();
        }
        
    }

    private void HitKnifeByKnife(KnifeView knife)
    {
        knife.IsReadyToMove = false;
        knife.IsCollisionKnifeByKnife = true;
        knife.OnTargetCicleCollision -= CollisionInTargetCicle;
        knife.BoxColliderOff();
    }

    private void CoinBonusCollision()
    {

    }
}
