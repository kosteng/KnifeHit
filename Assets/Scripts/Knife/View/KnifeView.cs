using System;
using UnityEngine;

public class KnifeView : MonoBehaviour
{
	public event Action OnKnifeCollision;
	public event Action OnCoinBonusCollision;
    public event Action OnTargetCicleCollision;
    public GameObject CollisionObject;

    public float Speed;
	public bool IsReadyToMove = false;
	public void Move()
	{
		transform.Translate(0f, Speed * Time.deltaTime, 0f);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("CoinBonus"))
		{
			OnCoinBonusCollision?.Invoke();
//			return;
		}
        if (collision.gameObject.CompareTag("TargetCicle"))
        {
            OnKnifeCollision?.Invoke();
            CollisionObject = collision.gameObject;
            Debug.Log(1);
//            return;
        }

        if (collision.gameObject == gameObject)
        {
            OnKnifeCollision?.Invoke();
//return;
        }
    }
}