using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string gameSceneName = "GameScene"; // Name of the game scene to load

    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        // Quit the application
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
        Application.Quit(); // Quit the application in a build
    }
}
