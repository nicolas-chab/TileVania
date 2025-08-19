using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    void Awake()
    {
        int numScenePersists = FindObjectsByType<ScenePersist>(FindObjectsSortMode.InstanceID).Length;

        if (numScenePersists > 1)
        {
            Destroy(gameObject); // Ensure only one GameSession exists
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Persist GameSession across scenes
        }

    }
    public void ResetScenePersist()
    {
        Destroy(gameObject); // Destroy the ScenePersist object
    }
}
