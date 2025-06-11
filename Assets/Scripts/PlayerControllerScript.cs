using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerScript : MonoBehaviour
{
    Rigidbody rigidbodyPlayer; // references the objects Rigidbody
    public float speed = 5f;
    private Vector3 jumpForce = new Vector3(0, 400, 0);
    private bool grounded;
    private InputAction moveAction;
    private InputAction jumpAction;
    private bool jumpRequested = false;
    private bool justJumped = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>(); //retreives the Rigidbody component
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();

        transform.Translate(Vector3.right * input.x * speed * Time.deltaTime);

        if (jumpAction.triggered) //checks if the jump button was pressed
        {
            jumpRequested = true; //allows the jump logic to execute
        }
    }

    void FixedUpdate() //rigidbody forces go here
    {
        if (jumpRequested && grounded) //checks if the jump button was pressed and if the player is touching the boudary
        {
            rigidbodyPlayer.AddForce(jumpForce, ForceMode.Impulse); //applies force to the Rigidbody
            grounded = false; //reset collision check
            justJumped = true;
        }
        jumpRequested = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Human")
        {
            Destroy(collision.gameObject); // Destroys the human object on collision
            // Handle collision with human object
            Debug.Log("Human killed!");
        }
    }

    void OnCollisionStay(Collision collision) //Checks whether the object is colliding with another object
    {
        if (justJumped) //Checks if the player jumped and is colliding with the floor
        {
            justJumped = false;
            return; //Allows the script to execute before collision detects the boundary using the return function
        }
        else if (collision.gameObject.tag == "Floor" && justJumped == false)
        {
            grounded = true; //Allows the player to jump again
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            grounded = false; // Player is no longer touching the floor
        }
    }
}

