using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private Rigidbody rock;

    [SerializeField] private float rockVelocity;

    [SerializeField] private GameObject eventTrigger;


    private void Update()
    {
        if (eventTrigger.activeInHierarchy)
        {
            rock.constraints = RigidbodyConstraints.FreezePositionZ;
            rock.constraints = RigidbodyConstraints.FreezePositionY;
            rock.transform.position = new Vector3(-17.94f, 2.3f, -11.09f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rock.constraints = ~(RigidbodyConstraints.FreezePositionZ);
            eventTrigger.SetActive(false);
            rock.AddForce(transform.forward * rockVelocity, ForceMode.Impulse);
        }

    }

}
