using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjetPlumeScript : ObjetsScript
{
    public float SpeedMult;
    public float BuffTime;
    
    private Collider _collider;

    protected override void UseItem(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _collider = other;
            //_collider.GetComponent<Player>().speed *2;

            Invoke("SpeedToNormal", 5f);

            
        }
    }

    private void SpeedToNormal()
    {
        //_collider.GetComponent<Player>().speed/2;
        DestroyObject();
    }
}
