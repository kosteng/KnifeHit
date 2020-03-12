using System;
using UnityEngine;

public class KnifeView : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private BoxCollider2D _boxCollider;

    public event Action OnKnifeCollision;
    public event Action OnCoinBonusCollision;
    public event Action OnTargetCicleCollision;

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

        }
        if (collision.gameObject.CompareTag("TargetCicle"))
        {
            CollisionObject = collision.gameObject;
            OnTargetCicleCollision?.Invoke();

        }
        if (collision.gameObject.CompareTag("Knife"))
        {
            OnKnifeCollision?.Invoke();
            Debug.Log(111);
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
    
    public void ActivedBoxCollider()
    {
        _boxCollider.enabled = true;
    }
    public void HitKnifeByKnife()
    {
        gameObject.transform.Rotate(10, 0, 10);
        gameObject.transform.Translate(10, -10, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
	{

        if (collision.gameObject == this)
        {
            OnKnifeCollision?.Invoke();
            Debug.Log(111);
        }
    }
}