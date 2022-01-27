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

    public override void OnSpecial()
    {
        if (Life.isDead) return;
        if (!SpecialActive) return;
        Instantiate(thunderPrefab,  transform.position + (transform.forward * 10), Quaternion.identity);
        ActivateSpecial(false);
        Timer = 0f;
    }
}
