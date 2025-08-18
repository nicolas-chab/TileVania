using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    BoxCollider2D myBoxCollider;
[SerializeField] float moveSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        // Initialize any other components or variables if needed
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.linearVelocity = new Vector2(moveSpeed, 0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        moveSpeed = -moveSpeed; // Reverse direction when hitting a wall
        flipenemySprite();
    }
    void flipenemySprite()
    {
        transform.localScale = new Vector2(-(math.sign(myRigidbody.linearVelocityX)), 1f);
    }
}
