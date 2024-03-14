using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints for the enemy to patrol
    public float speed = 2.0f; // Speed of the enemy
    private int currentWaypoint = 0; // Index of the current waypoint
    private int direction = 1; // Direction of movement (+1 for forward, -1 for backward)

    void Update()
    {
        

        // Move towards the current waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

        // Check if the enemy has reached the current waypoint
        if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.2f)
        {
            // Change direction when reaching the end waypoints
            if (currentWaypoint == waypoints.Length - 1 || currentWaypoint == 0)
            {
                direction *= -1;
            }

            // Move to the next waypoint based on the direction
            currentWaypoint += direction;

            // Ensure currentWaypoint stays within bounds
            currentWaypoint = Mathf.Clamp(currentWaypoint, 0, waypoints.Length - 1);
        }
    }
}
