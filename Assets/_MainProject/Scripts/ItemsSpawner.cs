using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemsSpawner : MonoBehaviour
{

    public GameObject[] Items = new GameObject[5];
    public List<GameObject> SpawnedItems = new List<GameObject>();

    public static bool InWave = false;

    public int MaxItemOnTerrain;
    public float TimeBeforeSpawn;
    public int Radius;
    public GameObject ItemsDetector;

    private bool isSpawning = false;

    private void StartCouroutine()
    {
        StartCoroutine(SpawnItems());
    }

    private void FixedUpdate()
    {
        if (InWave && !isSpawning)
        {
            Debug.Log("dddddddd");
            
            isSpawning = true;
            Invoke("StartCouroutine", 1f);
        }
    }

    IEnumerator SpawnItems()
    {
        while (SpawnedItems.Count < MaxItemOnTerrain)
        {
            isSpawning = true;
            Vector3 spherePos = Random.insideUnitSphere * Radius;
            Vector3 spawnPos = new Vector3(spherePos.x, 0, spherePos.z);
            transform.position = spawnPos;
            var item = Instantiate(Items[Random.Range(0, Items.Length)], transform.position, Quaternion.identity);
            item.transform.parent = ItemsDetector.transform;
            if (!SpawnedItems.Contains(item))
            {
                SpawnedItems.Add(item);
            }
            yield return new WaitForSeconds(TimeBeforeSpawn);
        }
        if(SpawnedItems.Count == MaxItemOnTerrain) isSpawning = false;
    }

    public void RemoveItemFromList(GameObject item)
    {
        SpawnedItems.Remove(item);
    }
}
