using System;
using UnityEngine;

public class TargetCicleView : MonoBehaviour
{
    public event Action OnTargetCicleCollision;

    public void OnUpdate()
    {

    }

    public void Rotate(float speedRotation)
    {
        transform.Rotate(Vector3.back, speedRotation * Time.deltaTime);
    }
}
