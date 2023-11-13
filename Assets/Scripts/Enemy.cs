using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody body;
    private Player player;

    private static int destroyedEnemies;

    private void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        body.AddForce((player.transform.position - transform.position).normalized * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Abyss"))
        {
            Destroy(gameObject);
            destroyedEnemies++;
        }
    }

    public static int DestroyedEnemies
    {
        get => destroyedEnemies;
        set => destroyedEnemies = value;
    }
}
