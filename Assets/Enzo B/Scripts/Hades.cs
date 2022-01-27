using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Hades : PlayerScript
{
    public GameObject skull;

    public int ennemyCursed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
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
        int nbr = 0;
        while (nbr <= ennemyCursed)
        {
            foreach (EnnemiesBehaviour enemy in EnnemiesBehaviour.EnnemiesList)
            {
                if (Random.value < 0.5f)
                {
                    enemy.cursed = true;
                    Instantiate(skull, enemy.transform.position + Vector3.up * 2f, Quaternion.identity, enemy.transform);
                    nbr++;
                }
                if (nbr <= ennemyCursed) break;
            }
        }
            
    }
}
