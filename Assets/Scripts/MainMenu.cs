using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _StartButton;
    [SerializeField] Button _QuitButton;
    
    void Start()
    {
        _StartButton.onClick.AddListener(StartB);
        _QuitButton.onClick.AddListener(Quit);
    }

    void StartB()
    {
        SceneManager.LoadScene(1);
    }

    void Quit()
    {
        Application.Quit();
    }
}
