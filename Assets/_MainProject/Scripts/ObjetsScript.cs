using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjetsScript : MonoBehaviour
{
    protected abstract void UseItem(Collider other);
    private ItemsSpawner itemsSpawner;

    private void Start()
    {
        GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");
        itemsSpawner = spawner.GetComponent<ItemsSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UseItem(other);
            
            itemsSpawner.RemoveItemFromList(this.gameObject);
            DespawnObject();
        }
    }

    private void DespawnObject()
    {
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
