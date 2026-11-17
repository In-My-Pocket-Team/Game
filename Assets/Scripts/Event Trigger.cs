using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private Rigidbody rock;

    [SerializeField] private float rockVelocity;

    [SerializeField] private GameObject eventTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rock.AddForce(transform.forward * rockVelocity, ForceMode.Impulse);
            eventTrigger.SetActive(false);
        }
    }

}
