using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

[System.Serializable]
public class LoadingTip
{
    public Sprite image;

    [TextArea(2, 4)]
    public string message;
}

public class LoadingManager : MonoBehaviour
{
    public static string sceneToLoad;

    [Header("UI References")]
    [SerializeField] private Image displayImage;
    [SerializeField] private TMP_Text displayText;

    [Header("Loading Messages")]
    [SerializeField] private LoadingTip[] loadingTips;

    [Header("Timing")]
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private float readingTime = 2f;

    public static void LoadScene(string sceneName)
    {
        sceneToLoad = sceneName;
        SceneManager.LoadScene("LoadingScreen");
    }

    private void Start()
    {
        StartCoroutine(LoadingSequence());
    }

    private IEnumerator LoadingSequence()
    {
        if (string.IsNullOrEmpty(sceneToLoad))
        {
            Debug.LogError("No scene has been selected to load!");
            yield break;
        }

        if (loadingTips == null || loadingTips.Length == 0)
        {
            Debug.LogError("No loading images or messages have been added!");
            yield break;
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        operation.allowSceneActivation = false;

        for (int i = 0; i < loadingTips.Length; i++)
        {
            displayImage.sprite = loadingTips[i].image;

            yield return StartCoroutine(TypeText(loadingTips[i].message));

            // Wait 2 seconds after the message has finished typing
            yield return new WaitForSecondsRealtime(readingTime);
        }

        while (operation.progress < 0.9f)
        {
            yield return null;
        }

        operation.allowSceneActivation = true;
    }

    private IEnumerator TypeText(string message)
    {
        displayText.text = "";

        foreach (char letter in message)
        {
            displayText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }
}
