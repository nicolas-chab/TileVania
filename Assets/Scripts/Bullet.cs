using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletspeed = 10f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float xspeed;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<PlayerMovement>();
        xspeed = player.transform.localScale.x * bulletspeed; // Set bullet speed based on player direction
    }

    void Update()
    {
        myRigidbody.linearVelocity = new Vector2(xspeed, 0f); // Move the bullet to the right

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject); // Destroy the enemy

        }

        Destroy(gameObject);

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject); // Destroy the bullet on collision
    }
    
}