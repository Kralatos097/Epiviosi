using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Athena : PlayerScript
{
    public GameObject shieldPrefab;
    public float shieldRange = 10f;
    
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
        foreach (PlayerScript player in PlayerList)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < shieldRange)
                Instantiate(shieldPrefab, player.transform);
        }
    }
}
