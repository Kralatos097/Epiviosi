using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjetCoeurScript : ObjetsScript
{
    public int PvHeal = 1;
    
    protected override void UseItem(Collider other)
    {
        other.GetComponent<PlayerScript>().Life.currentHp++;
        
        DestroyObject();
    }
}
