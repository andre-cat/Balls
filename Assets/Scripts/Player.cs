using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("REFERENCES")]
    [SerializeField] private RotatedCamera rotatedCamera;

    [Header("MOVEMENT")]
    [SerializeField] private float speed = 0f;

    private GameObject focalPoint;
    private Rigidbody body;

    private float forwardInput;
    private Powerup powerup;

    private void Start()
    {
        try
        {
            focalPoint = rotatedCamera.gameObject;
            body = gameObject.GetComponent<Rigidbody>();
            powerup = null;
        }
        catch (Exception e)
        {
            Debug.LogError("Hi: " + e);
        }

    }

    private void FixedUpdate()
    {
        try
        {
            TrackInput();
            Move();
        }
        catch (Exception e)
        {

            Debug.LogError("Hi: " + e);
        }
    }

    private void Move()
    {
        body.AddForce(forwardInput * speed * Time.deltaTime * focalPoint.transform.forward);
    }

    private void TrackInput()
    {
        forwardInput = Input.GetAxis("Vertical");
    }

    private IEnumerator UsePowerup(Powerup powerup)
    {
        this.powerup = powerup;
        this.powerup.TurnOnSpinner();
        yield return new WaitForSeconds(this.powerup.Seconds);
        this.powerup = null;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Powerup"))
        {
            if (powerup != null)
            {
                StopCoroutine(UsePowerup(collider.gameObject.GetComponent<Powerup>()));
            }
            StartCoroutine(UsePowerup(collider.gameObject.GetComponent<Powerup>()));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && powerup != null && powerup.Type == PowerupType.Contact)
        {
            Rigidbody enemyBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 playerEnemyDistance = collision.gameObject.transform.position - transform.position;
            //enemyBody.AddForce(playerEnemyDistance * powerupForce, ForceMode.Impulse);
        }
    }
}
