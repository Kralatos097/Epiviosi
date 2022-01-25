using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Player : MonoBehaviour
{
    public CharacterController controller;
    public float maxHp;
    public float speed = 3f;
    protected Vector2 Movement;
    protected Vector2 ValueCheck;
    

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
}
