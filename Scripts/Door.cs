using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindWithTag("Key") == null)
        {
            Destroy(gameObject);
        }
    }
}
