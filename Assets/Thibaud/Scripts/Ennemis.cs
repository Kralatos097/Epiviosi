using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemis : MonoBehaviour
{
    public static List<Ennemis> EnnemisList;

    private void Awake()
    {
        if (EnnemisList == null) EnnemisList = new List<Ennemis>();

        EnnemisList.Add(this);
    }

    private void OnDestroy()
    {
        EnnemisList.Remove(this);
    }
}
