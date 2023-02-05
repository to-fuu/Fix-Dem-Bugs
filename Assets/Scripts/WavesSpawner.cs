using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesSpawner : MonoBehaviour
{

    public static WavesSpawner instance;

    int wave;

    int spawnedEnemies;

    public List<GameObject> waves;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnWave()
    {
        if (waves[wave])
            Instantiate(waves[wave]);
        wave++;
    }


}
