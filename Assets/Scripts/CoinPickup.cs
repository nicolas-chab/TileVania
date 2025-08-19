using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSound;
    [SerializeField] int points = 100; // Points to add to the score when picked up
    bool isPickedUp = false; // To prevent multiple pickups
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& !isPickedUp)
        
        {
            isPickedUp = true; // Prevent multiple pickups
            FindAnyObjectByType<GameSession>().AddToScore(points); // Add points to the score
            gameObject.SetActive(false); // Disable the coin pickup object
            Destroy(gameObject); // Destroy the coin pickup object
            AudioSource.PlayClipAtPoint(coinPickupSound, Camera.main.transform.position);
            
        }
    }
}
