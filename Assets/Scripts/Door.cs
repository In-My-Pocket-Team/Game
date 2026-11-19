using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindWithTag("Key") == null)
        {
            gameObject.SetActive(false);
        }
    }
}
