using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Text _HealthText;

    void Awake() 
    {
        _HealthText = GetComponent<Text>();   
    }

    void Update()
    {
        _HealthText.text = GameTracker.Health.ToString();
    }
}
