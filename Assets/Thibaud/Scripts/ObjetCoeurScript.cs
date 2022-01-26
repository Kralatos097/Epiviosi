using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjetCoeurScript : ObjetsScript
{
    public int PvHeal = 1;
    
    protected override void UseItem(Collider other)
    {
        //Regen pv au joueur
    }
}
