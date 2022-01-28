using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public abstract class PlayerScript : MonoBehaviour
{
    public CharacterController controller;
    public int maxHp;
    public float speed = 3f;
    protected Vector2 Movement;
    protected Vector2 ValueCheck;
    public static List<PlayerScript> PlayerList = new List<PlayerScript>();
    protected float Timer;
    protected bool SpecialActive;
    public float coolDown;
    public bool ShieldActive = false;
    public bool BuffActive = false;
    public LifeSystem Life = new LifeSystem();
    public AttackZone AttackZone;
    public string UIParentName;
    public Image fillCooldown;
    public Text CooldownText;
    public Animator AnimatorPlayer;
    public Image lifeImage;

    private void Awake()
    {
        PlayerList.Add(this);
        Life.InitialiseLife(maxHp);
        GameObject UIGo = GameObject.Find(UIParentName);
        for (int index = 0; index < UIGo.transform.childCount; index++)
        {
            if (index == 1)
            {
                lifeImage = UIGo.transform.GetChild(index).GetComponent<Image>();
                break;
            }
        }
        CooldownText = UIGo.GetComponentInChildren<Text>();
        fillCooldown = CooldownText.transform.GetComponentInParent<Image>();
        fillCooldown.type = Image.Type.Filled;
        fillCooldown.fillOrigin = 2;
    }
    
    void Update()
    {
        lifeImage.fillAmount = (float)((float)Life.currentHp / (float)Life.maxHp);
        if (Life.isDead) return;
        Timer += Time.deltaTime;
        if (Timer >= coolDown)
        {
            ActivateSpecial(true);
            Timer = coolDown;
        }
        Move(Movement, speed);
        fillCooldown.fillAmount =  1 - Timer / coolDown;
        CooldownText.text = ((int)(coolDown - Timer)).ToString();

        AnimatorPlayer.SetFloat("movement", Movement.magnitude);
    }

    public void Move(Vector2 movement, float speed)
    {
        if (Life.isDead) return;
        controller.Move(new Vector3(movement.x, 0f, movement.y) * speed);
        transform.LookAt(transform.position + new Vector3(movement.x, 0f, movement.y));
    }

    public void OnAttack()
    {
        if (Life.isDead) return;
        foreach (EnnemiesBehaviour enemy in AttackZone.enemiesInZone)
        {
            enemy.GetHurt(BuffActive ? 2 : 1);
        }
        AttackZone.enemiesInZone.Clear();
        BuffActive = false;
        AnimatorPlayer.SetTrigger("attack");
    }

    public void OnMovement(InputValue value)
    {
        if (Life.isDead) return;
        ValueCheck = value.Get<Vector2>();
        if (ValueCheck.x < 0.5f && ValueCheck.x > -0.5f && ValueCheck.y < 0.5 && ValueCheck.y > -0.5f)
            Movement = Vector2.zero;
        else
            Movement = value.Get<Vector2>() * Time.deltaTime * speed;
    }

    public abstract void OnSpecial();

    public void ActivateSpecial(bool newState)
    {
        SpecialActive = newState;
        Timer = newState ? coolDown : 0f;
    }
}
