using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Vector3 rotation; //declare a Vector3
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotation = new Vector3(transform.rotation.x, 25f, transform.rotation.z); //store the axis the object will rotate on in the rotation variable
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime); //rotate the object
    }

}
