using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Zeus : PlayerScript
{
    public GameObject thunderPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= coolDown)
        {
            ActivateSpecial(true);
        }
        Move(Movement, speed);
    }

    public override void OnMovement(InputValue value)
    {
        ValueCheck = value.Get<Vector2>();
        if (ValueCheck.x < 0.5f && ValueCheck.x > -0.5f && ValueCheck.y < 0.5 && ValueCheck.y > -0.5f)
            Movement = Vector2.zero;
        else
            Movement = value.Get<Vector2>() * Time.deltaTime * speed;
    }

    public override void OnSpecial()
    {
        if (!SpecialActive) return;
        Instantiate(thunderPrefab,  transform.position + (transform.forward * 10), Quaternion.Euler(90, 0, 0));
        ActivateSpecial(false);
        Timer = 0f;
    }
}
