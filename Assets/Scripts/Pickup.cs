using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private GameObject Exit;
    private MeshRenderer material;
    [SerializeField] private Retry script;
    [SerializeField] private Material newmat;

    private void Start()
    {
        material = Exit.GetComponent<MeshRenderer>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Collect"))
            {
                gameObject.SetActive(false);
                material.material = newmat;
                script.OpenExit();
            }

            else if (gameObject.CompareTag("Key"))
            {
                gameObject.SetActive(false);
            }
        }
            
    }

}
