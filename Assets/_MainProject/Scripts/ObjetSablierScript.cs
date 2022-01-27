using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjetSablierScript : ObjetsScript
{
    protected override void UseItem(Collider other)
    {
        other.GetComponent<PlayerScript>().ActivateSpecial(true);
        
        DestroyObject();
    }
}
