using UnityEngine;

public class Activate : MonoBehaviour
{
   //add this script to a manager script then thats the one you connect to the player (all other objects keys, doors & collectables should also have this script)
    public void Reactivate()
    {
        // Finds all objects with the Activate Script & Activate them
        Activate [] foundObjects = FindObjectsByType<Activate>(
            FindObjectsInactive.Include,
            FindObjectsSortMode.None
        );

        foreach (Activate i in foundObjects)
        {
            i.gameObject.SetActive(true);
        }
    }
}
