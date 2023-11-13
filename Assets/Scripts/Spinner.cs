using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    private Transform me;
    private Transform powerupTransform;
    private Transform playerTransform;

    private float seconds;

    [SerializeField] private float rotationSpeed;

    public float Seconds { get => seconds; set => seconds = value; }

    private void Awake()
    {
        me = transform;
        powerupTransform = me.parent;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        seconds = 0;

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        me.position = playerTransform.position;

        float secondsElapsed = 0;

        while (secondsElapsed < seconds)
        {
            me.position = playerTransform.position;
            me.Rotate(Vector3.up * rotationSpeed);

            secondsElapsed += Time.deltaTime;
        }

        me.parent = powerupTransform;

        gameObject.SetActive(false);
    }
}
