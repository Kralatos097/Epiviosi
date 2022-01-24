using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static List<Player> PlayerList;

    private void Awake()
    {
        PlayerList.Add(this);
    }

    private void OnDestroy()
    {
        PlayerList.Remove(this);
    }
}
