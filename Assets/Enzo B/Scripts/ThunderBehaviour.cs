using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ThunderBehaviour : MonoBehaviour
{
    private List<NavMeshAgent> ennemiesAgents = new List<NavMeshAgent>();
    
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        foreach (NavMeshAgent agent in ennemiesAgents)
        {
            Debug.Log("GetKill 2PV " + agent.gameObject.name);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.TryGetComponent(out NavMeshAgent navMesh))
            ennemiesAgents.Add(navMesh);
    }
}
