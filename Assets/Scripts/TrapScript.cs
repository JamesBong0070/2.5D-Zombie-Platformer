using Unity.VisualScripting;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // Destroy the player object
            Debug.Log("Player has been killed!"); // Log a message to the console
        }
    }
}
