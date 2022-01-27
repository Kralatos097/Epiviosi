using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Poseidon : PlayerScript
{
    public GameObject typhoonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    public override void OnSpecial()
    {
        if (Life.isDead) return;
        if (!SpecialActive) return;
        Instantiate(typhoonPrefab,  transform.position + (transform.forward * 10), Quaternion.Euler(90, 0, 0));
        ActivateSpecial(false);
        Timer = 0f;
    }
}
