using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject Spawner1;
    [SerializeField] private GameObject Spawner2;
    [SerializeField] private GameObject Spawner3;
    [SerializeField] private GameObject Projectiles;

    private float timerend = 1f;
        private float timer = 0f;
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timerend)
        {
            timer -= timerend;
            StartCoroutine(Generate());
        }
    }

    private IEnumerator Generate()
    {
        int randomnum = 4;

        yield return new WaitForSeconds(0.5f);
        randomnum = Random.Range(0, 3);

        switch (randomnum)
        {
            
            case 0:
                Instantiate(Projectiles, new Vector3(Spawner1.transform.position.x, Spawner1.transform.position.y, Spawner1.transform.position.z), Quaternion.identity);
                break;

            case 1:
                Instantiate(Projectiles, new Vector3(Spawner2.transform.position.x, Spawner2.transform.position.y, Spawner2.transform.position.z), Quaternion.identity);
                break;

            case 2:
                Instantiate(Projectiles, new Vector3(Spawner3.transform.position.x, Spawner3.transform.position.y, Spawner3.transform.position.z), Quaternion.identity);
                break;
        }
    }
}
