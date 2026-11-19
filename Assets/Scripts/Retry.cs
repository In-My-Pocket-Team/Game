using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{

    private MeshRenderer material;
    [SerializeField] private Material newmat;
    [SerializeField] private Material oldmat;

    [SerializeField] private GameObject Exit;

    public bool open = false;
    public Fade_Out script;
    public Movement script1;

    private void Start()
    {
        material = Exit.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (GameObject.FindWithTag("Collect") == null)
        {
            open = true;
            material.material = newmat;
        }

        else if (GameObject.FindWithTag("Collect") != null)
        {
            material.material = oldmat;
        }

        if (script1.rewind == true)
        {
            open = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Retry") && script1.rewind == false)
        {
            script1.rewind = true;
            script1.ExecutePreviousInput();
            script1.allow_input = false;
        }

        if (other.gameObject.CompareTag("Exit") && open == false && script1.rewind == false)
        {
            script1.rewind = true;
            script1.ExecutePreviousInput();
            script1.allow_input = false;
        }

        else if (other.gameObject.CompareTag("Exit") && open == true)
        {
            script.FadeOut();
        }

        if (script1.currentInputIndex == script1.allocatedmoves && script1.rewind == false)
        {
            script1.rewind = true;
            script1.ExecutePreviousInput();
            script1.allow_input = false;
        }
    }

    public void OpenExit()
    {
        open = true;
    }
 
}
