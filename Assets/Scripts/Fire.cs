using UnityEngine;

public class Fire : MonoBehaviour
{
    private Vector3 direction = Vector3.forward;
    private float movespeed = 10f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        direction = Vector3.forward;
        rb.linearVelocity = direction * movespeed;
        Invoke(nameof(delete), 10f);
    }

    private void delete()
    {
        if (gameObject.name.Contains("(Clone)"))
        {
            Destroy(gameObject);
        }
    }
}
