using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjetFlecheScript : ObjetsScript
{
    public int Dmg = 1;
    public int NbCible = 3;
    
    EnnemiesBehaviour[] listEnn = new EnnemiesBehaviour[3];

    protected override void UseItem(Collider other)
    {
        GetEnnemisTouched();

        foreach (EnnemiesBehaviour ennemy in listEnn)
        {
            ennemy.GetHurt(Dmg);
        }
    }

    private void GetEnnemisTouched()
    {
        float distOne = 10000;
        float distTwo = 10000;
        float distThree = 10000;
        
        foreach (EnnemiesBehaviour enemy in EnnemiesBehaviour.EnnemiesList)
        {
            float dist = Vector3.Distance(enemy.transform.position, transform.position);

            if(dist < distOne)
            {
                if (dist < distTwo)
                {
                    if (dist < distThree)
                    {
                        distOne = distTwo;
                        distTwo = distThree;
                        distThree = dist;

                        listEnn[0] = listEnn[1];
                        listEnn[1] = listEnn[2];
                        listEnn[2] = enemy;
                    }
                    else
                    {
                        distOne = distTwo;
                        distTwo = dist;
                        
                        listEnn[0] = listEnn[1];
                        listEnn[1] = enemy;
                    }
                }
                else
                {
                    distOne = dist;
                    
                    listEnn[0] = enemy;
                }
            }
        }

        DestroyObject();
    }
}
