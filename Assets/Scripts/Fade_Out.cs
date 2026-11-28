using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade_Out : MonoBehaviour
{
    private Image Black;

    [Header("Scene Transition Settings")]
    [SerializeField] private string nextSceneName;

    [SerializeField] private bool useLoadingScreen;

    private void Start()
    {
        gameObject.SetActive(false);
        Black = GetComponent<Image>();
        Hide();
    }

    private void Hide()
    {
        Black.canvasRenderer.SetAlpha(0.0f);
    }

    public void FadeOut()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeAndLoadRoutine());
    }

    private IEnumerator FadeAndLoadRoutine()
    {
        Black.CrossFadeAlpha(1.0f, 2.0f, false);

        yield return new WaitForSeconds(2.0f);

        if (useLoadingScreen)
        {
            LoadingManager.LoadScene(nextSceneName);
        }
        else
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
