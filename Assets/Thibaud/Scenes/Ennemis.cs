using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemis : MonoBehaviour
{
    public static List<Ennemis> EnnemisList;

    private void Awake()
    {
        EnnemisList.Add(this);
    }

    private void OnDestroy()
    {
        EnnemisList.Remove(this);
    }
}
