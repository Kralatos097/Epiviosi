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

    public override void OnSpecial()
    {
        if (Life.isDead) return;
        if (!SpecialActive) return;
        foreach (PlayerScript player in PlayerList)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < shieldRange && !player.ShieldActive)
                Instantiate(shieldPrefab, player.transform);
        }
    }
}
