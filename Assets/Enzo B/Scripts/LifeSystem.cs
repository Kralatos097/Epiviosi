using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem
{
    private int _currentHp;
    public int currentHp
    {
        get => _currentHp;
        set
        {
            _currentHp = value;
            if (_currentHp >= maxHp)
            {
                _currentHp = maxHp;
                return;
            }
            if (_currentHp >= 0) return;
            _currentHp = 0;
            isDead = true;
        }
    }
    public int maxHp;

    public bool isDead = false;

    public void InitialiseLife(int playerMaxHp)
    {
        maxHp = playerMaxHp;
        currentHp = playerMaxHp;
    }

    public void GainLife(int gain)
    {
        currentHp += gain;
    }

    public void LossLife(int loss)
    {
        currentHp -= loss;
    }
}
