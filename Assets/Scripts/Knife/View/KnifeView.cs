using System;
using UnityEngine;

public class KnifeView : MonoBehaviour
{
	public event Action OnKnifeCollision;
	public event Action OnCoinBonusCollision;
    public event Action OnTargetCicleCollision;
    [SerializeField] private Rigidbody2D _rigidbody;


    public GameObject CollisionObject { get; private set; }

    public float Speed;
	public bool IsReadyToMove = false;
	public void Move()
	{
		transform.Translate(0f, Speed * Time.deltaTime, 0f);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CoinBonus"))
        {
            OnCoinBonusCollision?.Invoke();
            return;
        }
        if (collision.gameObject.tag == "TargetCicle")//CompareTag("TargetCicle"))
        {
            CollisionObject = collision.gameObject;
            OnTargetCicleCollision?.Invoke();
            return;
        }
    }

    public void RigidbodyDynamicBodyType()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    public void RigidbodyKinematicBodyType()
    {
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("CoinBonus"))
		{
			OnCoinBonusCollision?.Invoke();
		return;
		}
        if (collision.gameObject.tag == "TargetCicle")//CompareTag("TargetCicle"))
        {
            Debug.Log(1);
            OnKnifeCollision?.Invoke();
            CollisionObject = collision.gameObject;
           
            return;
        }

        if (collision.gameObject == gameObject)
        {
            OnKnifeCollision?.Invoke();
return;
        }
    }*/
}