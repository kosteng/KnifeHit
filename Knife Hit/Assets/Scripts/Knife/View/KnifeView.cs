using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeView : MonoBehaviour
{
    public void Move()
    {
        transform.Translate(0f, 10f * Time.deltaTime, 0f);
    }
}
