using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjetEpeeScript : ObjetsScript
{
    public float DmgMult = 2;

    protected override void UseItem(Collider other)
    {
        //other.GetComponent<PlayerScript>().atkDmg *= DmgMult;
    }
}
