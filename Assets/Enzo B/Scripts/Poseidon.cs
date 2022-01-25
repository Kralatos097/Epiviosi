using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Poseidon : Player
{
    private Vector2 movement;
    private float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(movement, speed);
    }

    public override void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>() * Time.deltaTime * speed;
    }

    public override void OnSpecial()
    {
        Debug.Log("Special");
    }
}
