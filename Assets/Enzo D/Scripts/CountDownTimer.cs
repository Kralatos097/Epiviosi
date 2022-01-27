using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDownTimer : MonoBehaviour
{

    [SerializeField] private Image timeImage;

    [SerializeField] private Text timeText;

    [SerializeField] private float duration, currenTime;
    
    void Start()
    {
       currenTime = duration;
       timeText.text = currenTime.ToString();
       StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while(currenTime >= 0)
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currenTime);
            timeText.text = currenTime.ToString();
            yield return new WaitForSeconds(1f);
            currenTime--;
        }
    }

    
}
