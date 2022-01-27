using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealSysteme : MonoBehaviour
{
    
    public float heal;
    public Lifesysteme playerhealth;
    public HealBar healthBar;
    public GameObject effect;
    private Transform player;
    public HealBar maxHealth;
    
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
 
    public void Use()
    {
        HealPlayer(2);
        Instantiate(effect, player.position, Quaternion.identity);
        Destroy(gameObject);
       
    }
 
    public void HealPlayer(int heal)
    {
 
 
        playerhealth.currentHealth += heal;
 
        healthBar.slider.fillAmount = playerhealth.currentHealth;
    }
    
    
}
