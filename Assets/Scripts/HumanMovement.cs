using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    private Transform target; // The target to run away from, typically the player
    private float compareDistance; // Variable to store the distance to the target
    public float speed = 5f;
    public float fleeRange = 5f; // Distance at which the human will start fleeing

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; // Find the player object in the scene by its tag
    }

    // Update is called once per frame
    void Update()
    {

        if (target != null) // Check if the target is assigned
        {
            compareDistance = Vector3.Distance(transform.position, target.position); // Initialize flee distance based on the initial distance to the player

            if (compareDistance < fleeRange && compareDistance > 1.5f) // Check if the target is within a certain distance (e.g., 5 units)
            {
                Vector3 direction = (target.position - transform.position).normalized; // Calculate the direction towards the target
                transform.position += -direction * speed * Time.deltaTime; // Move away from the target
                Debug.Log("Human is fleeing from the player!"); // Log fleeing action for debugging
            }
            else if (compareDistance < 1.5f) // If the distance is less than 1.5 units, stop moving
            {

            }
        }
    }
}