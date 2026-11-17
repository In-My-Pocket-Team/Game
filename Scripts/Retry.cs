using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    
    private MeshRenderer material;
    [SerializeField] private Material newmat;
    
    [SerializeField] private GameObject Exit;

    public bool open = false;
    public Fade_Out script;
    public Movement script1;

    private void Start()
    {
        material = Exit.GetComponent<MeshRenderer>();

        if (GameObject.FindWithTag("Collect") == null)
        {
            open = true;
            material.material = newmat;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Retry"))
        {
            SceneManager.LoadScene(1);
        }

        if (other.gameObject.CompareTag("Exit") && open == false)
        {
            SceneManager.LoadScene(1);
        }

        else if (other.gameObject.CompareTag("Exit") && open == true)
        {
            script.FadeOut();
        }

        if (script1.currentInputIndex == script1.allocatedmoves)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void OpenExit()
    {
        open = true;
    }
    
}
