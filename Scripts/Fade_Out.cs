using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Fade_Out : MonoBehaviour
{
    private Image Black; //store sprite in black

    private void Start() //when script 1st run
    {
        gameObject.SetActive(false); //turn off attached object
        Black = GetComponent<Image>(); //put the sprites image component in black
        Hide();//run the code in the hide block
    }

    private void Hide()
    {
        Black.canvasRenderer.SetAlpha(0.0f);//make the black sprite invisible
    }

    public void FadeOut()
    {
        gameObject.SetActive(true); //when run turn self on
        StartCoroutine(FadeAndLoadRoutine());
    }

    private IEnumerator FadeAndLoadRoutine()
    {
        Black.CrossFadeAlpha(1.0f, 2.0f, false); //overtime fully fade alpha in

        //wait 2 seconds before executing the stuff below
        yield return new WaitForSeconds(2.0f);

        //loadscene
        SceneManager.LoadScene(0);
    }
}
