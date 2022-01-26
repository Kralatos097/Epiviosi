using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemsSpawner : MonoBehaviour
{

    public GameObject[] Items = new GameObject[5];

    public int MaxItemOnTerrain;
    public int TimeBeforeSpawn;

    private int xPos;
    private int zPos;
    private int _itemsCount;

    void Start()
    {
        StartCoroutine(SpawnItems()); 
    }

    IEnumerator SpawnItems()
    {
        while (_itemsCount < MaxItemOnTerrain)
        {
            xPos = Random.Range(-20, 20);
            zPos = Random.Range(-20, 20);
            Instantiate(Items[Random.Range(0, Items.Length)], new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(TimeBeforeSpawn);
            _itemsCount += 1;
        }
    }
}
