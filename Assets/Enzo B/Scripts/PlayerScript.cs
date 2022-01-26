using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerScript : MonoBehaviour
{
    public CharacterController controller;
    public float maxHp;
    public float speed = 3f;
    protected Vector2 Movement;
    protected Vector2 ValueCheck;
    public static List<PlayerScript> PlayerList = new List<PlayerScript>();
    protected float Timer;
    protected bool SpecialActive;
    public float coolDown;

    private void Awake()
    {
        PlayerList.Add(this);
    }

    public void Move(Vector2 movement, float speed)
    {
        controller.Move(new Vector3(movement.x, 0f, movement.y) * speed);
        transform.LookAt(transform.position + new Vector3(movement.x, 0f, movement.y));
    }

    public void OnAttack()
    {
        Debug.Log("Attack");
    }

    public abstract void OnMovement(InputValue value);

    public abstract void OnSpecial();

    public void ActivateSpecial(bool newState)
    {
        SpecialActive = newState;
    }
}
