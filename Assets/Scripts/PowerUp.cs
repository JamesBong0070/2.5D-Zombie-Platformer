using UnityEngine;

public class PowerUp : MonoBehaviour
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
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroy the power-up object
            // Here you can add code to grant the power-up effect to the player
            // Grant power-up to player
            Debug.Log("Power-up collected!"); // Log message for debugging
        }
    }
}
