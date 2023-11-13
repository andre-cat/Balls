using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawner : MonoBehaviour
{

    [SerializeField][Min(0)] private float spawnSeconds;
    [SerializeField][Min(1)] private int spawnQuantity;
    [SerializeField] private GameObject[] spawnables;
    [SerializeField] private Transform spawnParent;
    [SerializeField] private Renderer zoneRenderer;

    float xMin, xMax;
    float zMin, zMax;

    private float secondsElapsed;

    private void Start()
    {
        xMin = zoneRenderer.gameObject.transform.position.x - zoneRenderer.bounds.size.x / 2;
        xMax = zoneRenderer.gameObject.transform.position.x + zoneRenderer.bounds.size.x / 2;
        zMin = zoneRenderer.gameObject.transform.position.z - zoneRenderer.bounds.size.z / 2;
        zMax = zoneRenderer.gameObject.transform.position.z + zoneRenderer.bounds.size.z / 2;

        secondsElapsed = spawnSeconds;
    }

    private void FixedUpdate()
    {
        SpawnInSeconds();
    }

    private void SpawnInSeconds()
    {
        if (secondsElapsed < spawnSeconds)
        {
            secondsElapsed += Time.deltaTime;
        }
        else
        {
            secondsElapsed = 0;

            for (int i = 0; i < spawnQuantity; i++)
            {
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(xMin, xMax), spawnParent.position.y, Random.Range(zMin, zMax));

        GameObject spawnable = spawnables[Random.Range(0, spawnables.Length)];

        GameObject spawned = Instantiate(spawnable, spawnPosition, spawnParent.rotation, spawnParent);

        spawned.SetActive(true);

    }
}
