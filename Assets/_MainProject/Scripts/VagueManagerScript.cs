using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagueManagerScript : MonoBehaviour
{
    //Public
    [Header("Values")]
    public int NbVagueFinale = 5;
    
    [Header("Drag'n Drop")]
    public Transform ListSpawnEnnemis;

    public Transform EnnemisParent;

    public GameObject EnnA;
    public GameObject EnnB;

    public float TimeBetweenWave;
    
    //Private
    public int _nbVague = 0;
    private float _waveTimer = 0;
    
    void Start()
    {
        _waveTimer = TimeBetweenWave;
        
        NewVague();
    }
    
    void Update()
    {
        if (CheckTimer()) Defaite();
        if (CheckPlayerAlive()) Defaite();
        if (CheckEnnemiAlive())
            if (_nbVague >= NbVagueFinale) Victoire();
            else
            {
                if (_waveTimer <= 0)
                {
                    NewVague();
                    _waveTimer = TimeBetweenWave;
                }
                else _waveTimer -= Time.deltaTime;
            }
    }

    //Lance une nouvelle manche
    private void NewVague()
    {
        Debug.Log("ffffffffffff");
        _nbVague++;
                
        PlayerFullHeal();
        EnnemisSpawn();
        
        //reactivate objects spawn
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
        int nbEnnemisB = Mathf.FloorToInt(Mathf.Pow(_nbVague-1, 1.5f) +4);
        int nbEnnemisA = Mathf.FloorToInt(Mathf.Pow(nbEnnemisB/5,1.1f));

        for (int i = 0; i < nbEnnemisB; i++)
        {
            SpawnOneEnnemi(0);
            Debug.Log("Spawn Enemy");

            if (i < nbEnnemisA)
            {
                SpawnOneEnnemi(1);
            }
        }
    }

    //si type = 1 spawn un ennemi avancé, snn spawn un ennemi basique
    private void SpawnOneEnnemi(int type)
    {
        GameObject goTemp;
        if (type == 1) goTemp = EnnA;
        else goTemp = EnnB;
        Instantiate(goTemp, GetRandomSpawn().position, Quaternion.identity, EnnemisParent);
    }

    private Transform GetRandomSpawn()
    {
        int rand = Random.Range(0,ListSpawnEnnemis.childCount);

        return ListSpawnEnnemis.GetChild(rand);
    }

    //Soigne tous les joueur en fin de manche
    private void PlayerFullHeal()
    {
        foreach (PlayerScript player in PlayerScript.PlayerList)
        {
            player.Life.InitialiseLife(player.maxHp);
        }
    }

    //return true si tous les joueur sont morts est finit, false snn
    private bool CheckPlayerAlive()
    {
        foreach (PlayerScript player in PlayerScript.PlayerList)
        {
            if(!player.Life.isDead)
            {
                return false;
            }
        }

        return true;
    }

    //return true si il n'y a pas d'ennemis est finit, false snn
    private bool CheckEnnemiAlive()
    {
        return EnnemiesBehaviour.EnnemiesList.Count <= 0;
    }

    //return true si le timer est finit, false snn
    private bool CheckTimer()
    {
        return Timer.TimerEnd;
    }
}
