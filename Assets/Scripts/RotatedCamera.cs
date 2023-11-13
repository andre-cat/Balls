using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatedCamera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 0f;

    private float horizontalInput;

    private void FixedUpdate()
    {
        TrackInput();
        Move();
    }

    private void Move()
    {
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }

    private void TrackInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

}
