using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
        
    }
    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(LevelLoadDelay); // Wait for 1 second before loading the next level
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0; // If it's the last scene, go back to the first scene
        }
        FindAnyObjectByType<ScenePersist>().ResetScenePersist(); // Reset the ScenePersist object
        SceneManager.LoadScene(nextSceneIndex); // Load the next scene
        
    }
}
