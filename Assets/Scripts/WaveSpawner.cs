using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] spawnables;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float checkEnemiesEvery;

    private string usedPoints;
    private float waveQuantity;

    private void Start()
    {
        waveQuantity = 0;
        InvokeRepeating(nameof(SpawnWave), 1, checkEnemiesEvery);
    }

    private void SpawnWave()
    {

        int enemiesQuantity = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemiesQuantity == 0 && spawnPoints.Length <= waveQuantity)
        {
            waveQuantity++;

            usedPoints = "#";

            for (int i = 0; i < waveQuantity; i++)
            {
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        int index = Random.Range(0, spawnPoints.Length);

        usedPoints += $"{index:D2}#";

        while (usedPoints.Contains($"#{index:D2}#"))
        {
            index = Random.Range(0, spawnPoints.Length);
        }

        Transform spawnTransform = spawnPoints[index];

        GameObject spawnable = spawnables[Random.Range(0, spawnables.Length)];

        Instantiate(spawnable, spawnTransform.position, spawnTransform.rotation, spawnTransform);
    }

}
