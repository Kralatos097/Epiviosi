using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifesysteme : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
 
    void Start()
    {
        currentHealth = maxHealth;
    }
}
