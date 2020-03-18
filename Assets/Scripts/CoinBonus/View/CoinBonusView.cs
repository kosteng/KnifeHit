using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinBonusView : MonoBehaviour
{
    public event Action OnCoinBonusByKnifeCollision;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Knife"))
        {
            OnCoinBonusByKnifeCollision?.Invoke();
        }
    }
}
