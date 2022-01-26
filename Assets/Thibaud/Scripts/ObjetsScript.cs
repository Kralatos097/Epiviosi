using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjetsScript : MonoBehaviour
{
    protected abstract void UseItem(Collider other);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UseItem(other);
            
            DespawnObject();
        }
    }

    private void DespawnObject()
    {
        //Object Spawn Count -1 dans le fichier ItemSpawner
            
        DeactivateCollider();
        DeactivateSprite();
    }

    protected void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void DeactivateSprite()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
    }

    private void DeactivateCollider()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
