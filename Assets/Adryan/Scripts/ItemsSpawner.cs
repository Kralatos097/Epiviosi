using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemsSpawner : MonoBehaviour
{

    public GameObject[] Items = new GameObject[5];

    public int MaxItemOnTerrain;
    public float TimeBeforeSpawn;
    public int Radius;

    private int _itemsCount;

    void Start()
    {
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (_itemsCount < MaxItemOnTerrain)
        {

           Vector3 spherePos = Random.insideUnitSphere * Radius;
            Vector3 spawnPos = new Vector3(spherePos.x, 0, spherePos.z);
            transform.position = spawnPos;
            Instantiate(Items[Random.Range(0, Items.Length)],transform.position, Quaternion.identity);
            yield return new WaitForSeconds(TimeBeforeSpawn);
            _itemsCount += 1;
        }
    }
}
