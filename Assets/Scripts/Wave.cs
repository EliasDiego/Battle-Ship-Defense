using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{
    Text _WaveText;

    void Awake() 
    {
        _WaveText = GetComponent<Text>();   
    }

    void Update()
    {
        _WaveText.text = GameTracker.Wave.ToString();
    }
}
