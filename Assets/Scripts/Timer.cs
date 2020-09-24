using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text _TimerText;

    void Awake() 
    {
        _TimerText = GetComponent<Text>();   
    }

    void Update()
    {
        GameTracker.TimeLeft -= Time.deltaTime;

        _TimerText.text = ((int)GameTracker.TimeLeft + 1).ToString();
    }
}
