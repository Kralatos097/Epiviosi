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
            agent.transform.GetComponent<EnnemiesBehaviour>().GetHurt(2);
        }

        foreach (PlayerScript player in PlayerScript.PlayerList)
        {
            player.AttackZone.enemiesInZone.Clear();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.TryGetComponent(out NavMeshAgent navMesh))
        {
            foreach (NavMeshAgent agent in ennemiesAgents)
            {
                if (agent == navMesh)
                    return;
            }
            ennemiesAgents.Add(navMesh);
        }
            
    }
}
