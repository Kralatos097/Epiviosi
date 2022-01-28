using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VagueManagerScript : MonoBehaviour
{
    //Public
    [Header("Values")]
    public int NbVagueFinale = 5;
    public float TimeBetweenWave;
    
    [Header("Drag'n Drop")]
    public Transform ListSpawnEnnemis;

    public Transform EnnemisParent;

    public GameObject EnnA;
    public GameObject EnnB;

    public GameObject PanelStart;
    public Text NbMancheText;
    
    //Private
    public int _nbVague = 0;
    private float _btWaveTimer = 0;
    private bool _partyStart = false;

    void Update()
    {
        if(CheckPlayerAlive() && !_partyStart)
        {
            return;
        }
        else if(_partyStart)
        {
            if (CheckTimer()) Defaite();
            if (CheckPlayerAlive()) Defaite();
            if (CheckEnnemiAlive())
            {
                if (_nbVague >= NbVagueFinale) Victoire();
                else
                {
                    gameObject.GetComponent<CountDownTimer>().TimerPause();
                    ItemsSpawner.InWave = false;
                    if (_btWaveTimer <= 0)
                    {
                        NewVague();
                        _btWaveTimer = TimeBetweenWave;
                    }
                    else _btWaveTimer -= Time.deltaTime;
                }
            }
        }
        else
        {
            _btWaveTimer = TimeBetweenWave;
        
            NewVague();
            gameObject.GetComponent<CountDownTimer>().RestartTimer();
            ItemsSpawner.InWave = true;
            PanelStart.SetActive(false);
            _partyStart = true;
        }
    }

    //Lance une nouvelle manche
    private void NewVague()
    {
        _nbVague++;
        NbMancheText.text = _nbVague.ToString();
                
        PlayerFullHeal();
        EnnemisSpawn();
        
        gameObject.GetComponent<CountDownTimer>().RestartTimer();
    }

    //Lance la victoire si toutes les manches sont réussie
    private void Victoire()
    {
        SceneManager.LoadSceneAsync("Victoire");
    }

    //Lance la défaite si tous les joueurs meurs ou si le timer est finit
    private void Defaite()
    {
        SceneManager.LoadSceneAsync("defaite");
    }

    //Fait apparaitre les ennemis au début d'une manche
    private void EnnemisSpawn()
    {
        int nbEnnemisB = Mathf.FloorToInt(Mathf.Pow(_nbVague-1, 2f) +6);
        int nbEnnemisA = Mathf.FloorToInt(Mathf.Pow(nbEnnemisB/5,1.3f));

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
        return gameObject.GetComponent<CountDownTimer>().TimerEnded;
    }
}
