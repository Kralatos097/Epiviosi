using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayeurLife : MonoBehaviour
{
    public float life;
    public float lifeMax;
    public GameObject handle;
    public Text lifeText;

    private RectTransform lifeBar;
    private float timer = 0.0f;
    private float waitTime = 0.5f;
    private bool isTrigger = false;
    void Start()
    {
        lifeBar = handle.GetComponent<RectTransform>();
        lifeText.text = "" + lifeMax;
        lifeBar.localScale = new Vector3(life / lifeMax, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            timer = 0.0f;
            if (isTrigger)
            {
                life = life - 1;
                lifeText.text = "" + life;
                lifeBar.localScale = new Vector3(life / lifeMax, 1, 1);
            }
        }
    }

    private void OnTriggerEnter(CapsuleCollider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit(CapsuleCollider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            isTrigger = false;
        }
    }
}
