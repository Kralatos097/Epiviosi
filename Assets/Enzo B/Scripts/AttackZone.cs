using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public List<EnnemiesBehaviour> enemiesInZone = new List<EnnemiesBehaviour>();

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.TryGetComponent(out EnnemiesBehaviour enemy))
        {
            foreach (EnnemiesBehaviour ennemies in enemiesInZone)
            {
                if (ennemies == enemy)
                    return;
            }
            enemiesInZone.Add(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.TryGetComponent(out EnnemiesBehaviour enemy))
        {
            foreach (EnnemiesBehaviour ennemies in enemiesInZone)
            {
                if (ennemies != enemy)
                    return;
            }
            enemiesInZone.Remove(enemy);
        }
    }
}
