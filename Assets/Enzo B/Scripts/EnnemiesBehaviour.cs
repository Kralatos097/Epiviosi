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
    public float changePlayerFactor = 1.5f;
    public static List<EnnemiesBehaviour> EnnemiesList = new List<EnnemiesBehaviour>();
    public float attackRange;
    public float attackBuffer;
    private float _attackCooldown;
    public int health = 2;
    public LifeSystem Life = new LifeSystem();
    public bool cursed = false;

    private void Awake()
    {
        Life.InitialiseLife(health);
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        EnnemiesList.Add(this);
        agent.speed = speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        _attackCooldown += Time.deltaTime;

        float distance = float.MaxValue;
        if (_playerAimed != null)
        {
            int index = 0;
            foreach (Vector3 corner in agent.path.corners)
            {
                distance += Vector3.Distance(corner, index == 0 ? transform.position : agent.path.corners[index - 1]);
                index++;
            }
        }
        
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            NavMeshPath path = new NavMeshPath();
            float newPlayerDistance = 0f;
            agent.CalculatePath(player.transform.position, path);

            //Check if it's reachable
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                //Calculate path lenght
                int index = 0;
                foreach (Vector3 corner in path.corners)
                {
                    newPlayerDistance += Vector3.Distance(corner, index == 0 ? transform.position : path.corners[index - 1]);
                    //No need to go further if the distance is already bigger
                    if (newPlayerDistance * changePlayerFactor >= distance)
                        break;
                    index++;
                }
            }
            else
            {
                newPlayerDistance = float.MaxValue;
            }
            if (newPlayerDistance * changePlayerFactor <= distance)
            {
                _playerAimed = player;
                distance = newPlayerDistance;
            }
        }
        if (!_playerAimed) return;

        if (Vector3.Distance(_playerAimed.transform.position, transform.position) >= attackRange)
            agent.destination = _playerAimed.transform.position;
        else
        {
            agent.destination = transform.position;
            transform.forward = _playerAimed.transform.position - transform.position;
            transform.forward = new Vector3(transform.forward.x, 0f, transform.forward.z);
            AttackPlayer(_playerAimed);
        }
    }

    void AttackPlayer(GameObject player)
    {
        if (_attackCooldown >= attackBuffer)
        {
            //Verifie si le personnage a un shield
            if (player.GetComponent<PlayerScript>().ShieldActive)
            {
                Destroy(player.GetComponentInChildren<ShieldBehaviour>().gameObject);
                _attackCooldown = 0f;
            }
            else
            {
                _attackCooldown = 0f;
                player.GetComponent<PlayerScript>().Life.LossLife(1);
            }
        }
    }

    public void GetHurt(int healthLost)
    {
        if (cursed)
            Destroy(transform.GetChild(0).gameObject);
        Life.LossLife(cursed ? healthLost * 2 : healthLost);
        cursed = false;
        if (Life.isDead)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EnnemiesList.Remove(this);
    }
}
