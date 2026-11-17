using UnityEngine;
using UnityEngine.AI;

public class E_Pathing : MonoBehaviour
{
    [SerializeField] private GameObject Start_Point;//the object the enemy will move towards
    [SerializeField] private GameObject End_Point;//the object the enemy will move towards
    public int Current_Point = 0;
    private bool return_state = false;
    public float movespeed;
    public float turn_speed = 500f; //how fast the enemy spins to face the target
    private GameObject Pathpoint;
    public string targetObjectName;
    public int Final_Point = 0;

   
    private void Start()
    {
        // Set the initial point so the enemy knows where to go first
        NextPoint();
    }

    private void Update()
    {
        
        if (Pathpoint != null)
        {
            // Find where the point is relative to the enemy
            Vector3 target_direction = Pathpoint.transform.position - transform.position;

            // Turn towards the point
            Quaternion target_rotation = Quaternion.LookRotation(target_direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target_rotation, turn_speed * Time.deltaTime);

            // Move towards the point
            transform.position = Vector3.MoveTowards(transform.position, Pathpoint.transform.position, movespeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) //upon a collision
    {
        //'return_state == false' check so it only triggers ONCE when arriving at the end
        if (other.gameObject == Start_Point && return_state == true)
        {
            return_state = false;
            PointDirection();
        }
        //'return_state == true' check so it only triggers ONCE when arriving at the start
        else if (other.gameObject == End_Point && return_state == false && Current_Point == Final_Point)
        {
            return_state = true;
            PointDirection();
        }
        else if (other.gameObject.name == targetObjectName + Current_Point.ToString())
        {
            PointDirection();
        }
    }

    private void PointDirection()
    {
        if (return_state == false)
        {
            Current_Point++;
            NextPoint();
        }
        else
        {
            Current_Point--;
            NextPoint();
        }
    }

    // Helper method to look up the next GameObject in the scene hierarchy
    private void NextPoint()
    {
        Pathpoint = GameObject.Find(targetObjectName + Current_Point.ToString());
    }
}