using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiesBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed;
    private Vector3 _playerDestination;

    private void Awake()
    {
        if (agent == null) agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Single.MaxValue;
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            NavMeshPath path = new NavMeshPath();
            float newPlayerDistance = 0f;
            agent.CalculatePath(player.transform.position, path);
            int index = 0;
            //Calculate path lenght
            foreach (Vector3 corner in path.corners)
            {
                newPlayerDistance += Vector3.Distance(corner, index == 0 ? transform.position : path.corners[index - 1]);
                //No need to go further if the distance is already bigger
                if (newPlayerDistance >= distance)
                    break;
                index++;
            }
            if (newPlayerDistance <= distance)
            {
                _playerDestination = player.transform.position;
            }

        }

        agent.destination = _playerDestination;
    }
}
