using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjetsScript : MonoBehaviour
{
    protected abstract void UseItem(Collider other);

    private void OnTriggerEnter(Collider other)
    {
        UseItem(other);
    }

    protected void DestroyObject()
    {
        Destroy(gameObject);
    }

    protected void DeactivateSprite()
    {
        
    }
    
    protected void DeactivateCollider()
    {
        
    }
}
