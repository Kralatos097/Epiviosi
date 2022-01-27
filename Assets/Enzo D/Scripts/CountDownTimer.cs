using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDownTimer : MonoBehaviour
{

    [SerializeField] private Image timeImage;

    [SerializeField] private Text timeText;

    [SerializeField] private float duration, currenTime;
    
    private float durationP, currenPTime;

    public bool TimerEnded = false;
    private bool _timerPaused = false;
    
    void Start()
    {
       currenTime = duration;
       timeText.text = currenTime.ToString();
    }

    IEnumerator TimeIEn()
    {
        while(currenTime >= 0 && !_timerPaused)
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currenTime);
            timeText.text = currenTime.ToString();
            yield return new WaitForSeconds(1f);
            currenTime--;
        }

        if (currenTime < 0)
        {
            TimerEnded = true;
        }
    }

    public void RestartTimer()
    {
        currenTime = duration;
        TimerEnded = false;
        
        _timerPaused = false;
        
        StartCoroutine(TimeIEn());
    }

    public void TimerPause()
    {
        timeImage.fillAmount = 0;
        timeText.text = "";

        _timerPaused = true;
    }
}
