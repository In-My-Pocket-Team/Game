using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    public void LoadLevel3()
    {
        LoadingManager.LoadScene("School 3");
    }

    // We will use this when your Ending scene is created.
    public void LoadEnding()
    {
        LoadingManager.LoadScene("Ending");
    }
}
