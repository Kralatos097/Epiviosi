using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiesBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed = 3.5f;
    private GameObject _playerAimed;
    public static List<EnnemiesBehaviour> EnnemiesList = new List<EnnemiesBehaviour>();
    public float attackRange;
    public float attackBuffer;
    private float _attackCooldown;
    private int _health = 2;

    private void Awake()
    {
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        EnnemiesList.Add(this);
        agent.speed = speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _attackCooldown += Time.deltaTime;
        
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
                _playerAimed = player;
                distance = newPlayerDistance;
            }
        }

        if (Vector3.Distance(_playerAimed.transform.position, transform.position) >= attackRange)
            agent.destination = _playerAimed.transform.position;
        else
        {
            agent.destination = transform.position;
            AttackPlayer(_playerAimed);
        }
    }

    void AttackPlayer(GameObject player)
    {
        if (_attackCooldown >= attackBuffer)
        {
            Debug.Log("Enemies Attack " + player.name + "!");
            _attackCooldown = 0f;
        }
    }

    public void GetHurt()
    {
        _health--;
        if (_health <= 0)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EnnemiesList.Remove(this);
    }
}
