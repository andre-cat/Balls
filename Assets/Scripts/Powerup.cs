using System.Collections;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private Spinner spinner;
    [SerializeField] private PowerupType type;
    [SerializeField] private float seconds;

    public PowerupType Type { get => type; }
    public float Seconds { get => seconds; }

    public void TurnOnSpinner()
    {
        spinner.gameObject.SetActive(true);
        spinner.transform.parent = null;
        gameObject.SetActive(false);
    }

    private void Start()
    {
        spinner.Seconds = seconds;
    }
}
