using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCicleView : View
{      
    public void OnUpdate()
    {
        
    }
    
    public void Rotate(float speedRotation)
    {
        transform.Rotate(Vector3.back, speedRotation * Time.deltaTime);
    }
}
