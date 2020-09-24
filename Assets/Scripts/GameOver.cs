using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] Text _WavesText;
    [SerializeField] Text _SwarmText;
    [SerializeField] Text _ReflectorText;
    [SerializeField] Text _HeavyText;
    [SerializeField] Button _TryAgainButton;
    [SerializeField] Button _MainMenuButton;

    void Start()
    {
        _TryAgainButton.onClick.AddListener(TryAgain);
        _MainMenuButton.onClick.AddListener(MainMenu);

        _WavesText.text = (GameTracker.Wave - 1).ToString();
        _SwarmText.text = GameTracker.SwarmMissileDestroyed.ToString();
        _ReflectorText.text = GameTracker.ReflectorMissileDestroyed.ToString();
        _HeavyText.text = GameTracker.HeavyMissileDestroyed.ToString();
    }

    void TryAgain()
    {
        GameTracker.Reset();
        SceneManager.LoadScene(2);
    }

    void MainMenu()
    {
        GameTracker.Reset();
        SceneManager.LoadScene(0);
    }
}
