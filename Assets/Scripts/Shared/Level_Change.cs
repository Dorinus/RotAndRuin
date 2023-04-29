using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Change : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Dectected!");
            SceneManager.LoadScene(sceneName);
            
        }
    }
}