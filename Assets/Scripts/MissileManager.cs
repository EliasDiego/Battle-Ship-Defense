using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YergoScripts.ObjectPool;

public class MissileManager : MonoBehaviour
{
    SpawnArea _SpawnArea;

    void Awake()
    {
        _SpawnArea = GetComponent<SpawnArea>();

        _SpawnArea.Instantiate();

        StartCoroutine(WaveFlow());

        GameTracker.Reset();
    }

    void Update() 
    {
        if(GameTracker.Health <= 0)   
            SceneManager.LoadScene(3);
    }

    IEnumerator WaveFlow()
    {
        // Wave 1
        StartCoroutine(SpawnMissile(0, 20, 2));

        yield return new WaitForSeconds(10);
        GameTracker.Wave++;
        GameTracker.TimeLeft = 10;
        // Wave 2
        StartCoroutine(SpawnMissile(1, 10, 5));

        yield return new WaitForSeconds(10);
        GameTracker.Wave++;
        GameTracker.TimeLeft = 10;

        // Wave 3
        StartCoroutine(SpawnMissile(2, 5, 10));

        yield return new WaitForSeconds(10);
        GameTracker.Wave++;
        GameTracker.TimeLeft = 10;

        // Wave n
        StartCoroutine(NWave());
    }

    IEnumerator NWave()
    {
        StartCoroutine(SpawnMissile(0, 20, 10));
        StartCoroutine(SpawnMissile(1, 10, 10));
        StartCoroutine(SpawnMissile(2, 5, 10));

        yield return new WaitForSeconds(10);
        GameTracker.Wave++;
        GameTracker.TimeLeft = 10;

        StartCoroutine(NWave());
    }

    IEnumerator SpawnMissile(int index, int numMissiles, int numSubWaves)
    {
        _SpawnArea.Spawn(index, numMissiles);

        yield return new WaitForSeconds(10 / numSubWaves);

        for(int i = 1; i <= numSubWaves; i++)
        {
            _SpawnArea.Spawn(index, numMissiles);
            yield return new WaitForSeconds(10 / numSubWaves);
        }
    }
}
