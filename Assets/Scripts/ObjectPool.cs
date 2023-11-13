using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField][Min(0)] private float initialDelay;
    [SerializeField][Min(0)] private float takeOutEvery;
    [SerializeField] private GameObject[] swimmers;
    [SerializeField][Min(1)] private int quantity;
    [SerializeField] private Transform pool;
    [SerializeField] private Renderer zoneRenderer;

    float xMin, xMax;
    float zMin, zMax;

    private void Start()
    {
        xMin = zoneRenderer.gameObject.transform.position.x - zoneRenderer.bounds.size.x / 2;
        xMax = zoneRenderer.gameObject.transform.position.x + zoneRenderer.bounds.size.x / 2;
        zMin = zoneRenderer.gameObject.transform.position.z - zoneRenderer.bounds.size.z / 2;
        zMax = zoneRenderer.gameObject.transform.position.z + zoneRenderer.bounds.size.z / 2;

        FillPool(swimmers, quantity);

        InvokeRepeating(nameof(DrainPool), initialDelay, takeOutEvery);
    }

    private void FillPool(GameObject[] swimmers, int quantity)
    {
        foreach (GameObject swimmer in swimmers)
        {
            for (int i = 0; i < quantity; i++)
            {
                Vector3 position = new(Random.Range(xMin, xMax), transform.position.y, Random.Range(zMin, zMax));

                PushOne(swimmer, position, transform.rotation, pool);
            }
        }
    }

    private void PushOne(GameObject swimmer, Vector3 position, Quaternion rotation, Transform pool)
    {
        GameObject swimmerInstance = Instantiate(swimmer, position, rotation);

        if (pool != null)
        {
            swimmerInstance.transform.parent = pool;
        }

        swimmerInstance.SetActive(false);
    }

    private void DrainPool()
    {
        GameObject takenSwimmer = PullOne(pool);

        if (!takenSwimmer.activeSelf)
        {
            takenSwimmer.SetActive(true);
        }
    }

    private GameObject PullOne(Transform pool)
    {
        return pool.GetChild(Random.Range(0, pool.childCount - 1)).gameObject;
    }
}
