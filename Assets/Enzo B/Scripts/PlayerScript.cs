using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerScript : MonoBehaviour
{
    public CharacterController controller;
    public int maxHp;
    public float speed = 3f;
    protected Vector2 Movement;
    protected Vector2 ValueCheck;
    public static List<PlayerScript> PlayerList = new List<PlayerScript>();
    protected float Timer;
    protected bool SpecialActive;
    public float coolDown;
    public bool ShieldActive = false;
    public bool BuffActive = false;
    public LifeSystem Life = new LifeSystem();
    public AttackZone AttackZone;

    private void Awake()
    {
        PlayerList.Add(this);
        Life.InitialiseLife(maxHp);
    }

    public void Move(Vector2 movement, float speed)
    {
        controller.Move(new Vector3(movement.x, 0f, movement.y) * speed);
        transform.LookAt(transform.position + new Vector3(movement.x, 0f, movement.y));
    }

    public void OnAttack()
    {
        foreach (EnnemiesBehaviour enemy in AttackZone.enemiesInZone)
        {
            enemy.GetHurt(BuffActive ? 2 : 1);
        }
        BuffActive = false;
    }

    public abstract void OnMovement(InputValue value);

    public abstract void OnSpecial();

    public void ActivateSpecial(bool newState)
    {
        SpecialActive = newState;
    }
}
