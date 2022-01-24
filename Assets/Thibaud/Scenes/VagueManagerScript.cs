using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagueManagerScript : MonoBehaviour
{
    public int NbVagueFinale = 5;
    
    private int _nbVague = 0;

    // Start is called before the first frame update
    void Start()
    {
        NewVague();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckTimer()) Defaite();
        if (CheckPlayerAlive()) Defaite();
        if (CheckEnnemiAlive())
            if (_nbVague >= NbVagueFinale) Victoire();
            else NewVague();
    }

    //Lance une nouvelle manche
    public void NewVague()
    {
        _nbVague++;
        PlayerFullHeal();
        EnnemisSpawn();
    }

    //Lance la victoire si toutes les manches sont réussie
    private void Victoire()
    {
        
    }

    //Lance la défaite si tous les joueurs meurs ou si le timer est finit
    private void Defaite()
    {
        
    }

    //Fait apparaitre les ennemis au début d'une manche
    private void EnnemisSpawn()
    {
        int nbEnnemisB = Mathf.FloorToInt(_nbVague / 2 + 4);
        int nbEnnemisA = Mathf.FloorToInt(Mathf.Pow(_nbVague * 2 + 4 - nbEnnemisB,1.1f));
    }

    //Soigne tous les joueur en fin de manche
    private void PlayerFullHeal()
    {
        
    }

    //return true si tous les joueur sont morts est finit, false snn
    private bool CheckPlayerAlive()
    {
        return true;
    }

    //return true si il n'y a pas d'ennemis est finit, false snn
    private bool CheckEnnemiAlive()
    {
        return true;
    }

    //return true si le timer est finit, false snn
    private bool CheckTimer()
    {
        return true;
    }
}
