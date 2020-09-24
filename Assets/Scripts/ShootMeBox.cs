using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootMeBox : Missile
{
    void Update()
    {
        if(Health <= 0)
            SceneManager.LoadScene(2);
    }
}
