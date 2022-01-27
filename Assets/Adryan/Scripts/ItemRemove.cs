using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemove : MonoBehaviour
{

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
            //l'item fait son boulot et s'enleve
            itemsSpawner.RemoveItemFromList(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
