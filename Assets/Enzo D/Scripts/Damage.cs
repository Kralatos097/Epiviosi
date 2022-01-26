using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damage;
        [SerializeField] private Lifesysteme playerhealth;
        [SerializeField] private HealBar healthBar;
 
        private void OnTriggerEnter2D(Collider2D Collision)
        {
            if (Collision.CompareTag("Player"))
            {
                DoDamage(10);
            }
        }
 
        void DoDamage(int damage)
        {
 
 
            playerhealth.currentHealth -= damage;
 
            healthBar.slider.fillAmount = playerhealth.currentHealth;
        }
}
