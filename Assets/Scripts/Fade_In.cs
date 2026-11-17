using UnityEngine;
using UnityEngine.UI;
public class Fade_In : MonoBehaviour
{
    private Image Black; //store sprite in black

    private void Start() //when script 1st run
    {
        Black = GetComponent<Image>(); //put the sprites image component in black
        Hide();
    }

    private void Update()
    {
        Black.CrossFadeAlpha(0, 2.0f, false); //overtime fully fade alpha out
    }

    private void Hide()
    {
        Black.canvasRenderer.SetAlpha(1.0f);//make the black sprite visible
    }

}