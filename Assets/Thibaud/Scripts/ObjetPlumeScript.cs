using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjetPlumeScript : ObjetsScript
{
    public float SpeedMult = 2;
    public float BuffTime = 5;
    
    private Collider _collider;

    protected override void UseItem(Collider other)
    {
        _collider = other;
        _collider.GetComponent<PlayerScript>().speed *= SpeedMult;

        Invoke("SpeedToNormal", BuffTime);
    }

    private void SpeedToNormal()
    {
        _collider.GetComponent<PlayerScript>().speed /= SpeedMult;
        DestroyObject();
    }
}
