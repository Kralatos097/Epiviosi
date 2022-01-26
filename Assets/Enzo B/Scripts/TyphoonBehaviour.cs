using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TyphoonBehaviour : MonoBehaviour
{
    private List<NavMeshAgent> ennemiesAgents = new List<NavMeshAgent>();

    private float timer;

    // Update is called once per frame
    void Update()
    {
        if (ennemiesAgents.Count > 0)
            foreach (NavMeshAgent ennemieAgent in ennemiesAgents)
            {
                ennemieAgent.updateRotation = false;
                ennemieAgent.destination = transform.position;
                NavMeshHit hit;
                bool aviable = ennemieAgent.Raycast(transform.position, out hit);
                Debug.DrawLine(transform.position, ennemieAgent.transform.position, aviable ? Color.green : Color.red);
                ennemieAgent.speed = 2;
            }

        if (timer >= 5f)
            Destroy(gameObject);
        timer += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out NavMeshAgent navMesh))
            ennemiesAgents.Add(navMesh);
    }

    private void OnDestroy()
    {
        foreach (NavMeshAgent ennemieAgent in ennemiesAgents)
        {
            ennemieAgent.updateRotation = true;
            ennemieAgent.speed = 3.5f;
        }
    }
}
