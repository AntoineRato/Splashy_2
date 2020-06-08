using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowMotionTimer : MonoBehaviour
{
    private Text textTimer;

    private void OnEnable()
    {
        textTimer = this.GetComponent<Text>();
        textTimer.text = "3";
        StartCoroutine(Timer(1));
    }

    private IEnumerator Timer(int timerStep)
    {
        if(timerStep == 1)
        {
            yield return new WaitForSeconds(0.00033f);
            textTimer.text = "2";
            StartCoroutine(Timer(2));
        }
        else if(timerStep == 2)
        {
            yield return new WaitForSeconds(0.00033f);
            textTimer.text = "1";
            StartCoroutine(Timer(3));
        }
        else if(timerStep == 3)
        {
            yield return new WaitForSeconds(0.00033f);
            textTimer.text = "";
            this.gameObject.SetActive(false);
        }
    }
}
