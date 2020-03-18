using System;
using UnityEngine;

public class KnifeView : MonoBehaviour
{
    private float _speed = 5;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private BoxCollider2D _boxCollider;

    public delegate void KnifeByKnifeCollisionHandler(KnifeView knife);
    public delegate void KnifeByTargetCicleCollisionHandler(KnifeView knife, GameObject targetCicle);
    public event KnifeByKnifeCollisionHandler OnKnifeCollision;
    public event Action OnCoinBonusCollision;
    public event KnifeByTargetCicleCollisionHandler OnTargetCicleCollision;

    public GameObject CollisionObject { get; private set; }

    public float Speed;
	public bool IsReadyToMove = false;
    public bool IsCollisionKnifeByKnife = false;

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
            OnTargetCicleCollision?.Invoke(this, collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Knife"))
        {
            OnKnifeCollision?.Invoke(this);
            Debug.Log(111);
        }
    }

    public void HitKnifeByKnifeMove()
    {
        gameObject.transform.Translate(_speed * Time.deltaTime, -_speed * Time.deltaTime, 0);
    }

    public void MoveToStartPosition()
    {
        transform.Translate(0, 10 * Time.deltaTime, 0);
    }

    public void BoxColliderOff()
    {
        _boxCollider.enabled = false;
    }

}