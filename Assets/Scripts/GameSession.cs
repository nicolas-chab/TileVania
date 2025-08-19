using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score=0;
    void Awake()
    {
        int numGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.InstanceID).Length;

        if (numGameSessions > 1)
        {
            Destroy(gameObject); // Ensure only one GameSession exists
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Persist GameSession across scenes
        }

    }
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }
    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddToScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }
    private void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex); // Reload the current scene
        livesText.text = playerLives.ToString();
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0); // Load the first scene
        FindAnyObjectByType<ScenePersist>().ResetScenePersist(); // Reset the ScenePersist object
        Destroy(gameObject); // Destroy the GameSession object
    }
}
