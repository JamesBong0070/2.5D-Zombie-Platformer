using UnityEngine;

public class HumanBoundary : MonoBehaviour
{
    public GameObject playerObject; // Reference to the player object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), playerObject.GetComponent<Collider>());
        // This line ensures that the boundary does not collide with the player object.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
