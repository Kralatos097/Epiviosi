using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 movement;
    public float speed = 3f;

    private void Update()
    {
        transform.position += new Vector3(movement.x, 0f, movement.y);
    }

    public void OnAttack()
    {
        Debug.Log("Attack");
    }

    public void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>() * Time.deltaTime * speed;
    }

    public void OnSpecial()
    {
        Debug.Log("Special");
    }
}
