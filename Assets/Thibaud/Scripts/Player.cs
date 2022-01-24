using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static List<Player> PlayerList = new List<Player>();
    
    public int pvMax;

                           
    private int _pv;
    [HideInInspector]
    public int pv
    {
        get => _pv;

        set
        {
            if(_pv + value <= 0)
            {
                _pv = 0;

                isDead = true;
            }
            else if(_pv + value > pvMax)
            {
                _pv = pvMax;
            }
        }
    }

    public bool isDead; //false si vivant et true si mort

    private void Awake()
    {
        if (PlayerList == null) PlayerList = new List<Player>();
        PlayerList.Add(this);
    }

    private void OnDestroy()
    {
        PlayerList.Remove(this);
    }
}
