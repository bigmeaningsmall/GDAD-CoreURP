using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public InputHandler inputHandler; // Reference to the inputHandler script
    private Vector2 leftStickInput;    // Vector2 to store the left stick input
    private bool buttonSouth;           // Boolean to store the button south input
    
    [Header("Movement Settings")]
    public float moveSpeed = 5f;      // Speed of movement on the plane
    public float jumpForce = 5f;      // Upward force applied for jumps
    public float gravityMultiplier = 2f; // Multiplier for gravity when falling

    private Rigidbody rb;
    private bool isGrounded;

    
    #region inputHandler Events Subscription
    private void OnEnable()
    {
        // Subscribe to inputHandler events
        inputHandler.OnLeftStick += LeftStick;
        inputHandler.OnButtonSouth += ButtonSouth;
        //
        //
        // // Subscribe to canceled events
        // inputHandler.OnButtonSouthCanceled += ButtonSouthCanceled;
    }

    private void OnDisable()
    {
        // Unsubscribe from inputHandler events
        inputHandler.OnLeftStick -= LeftStick;
        inputHandler.OnButtonSouth -= ButtonSouth;
        //
        // // Unsubscribe from canceled events
        //
        // inputHandler.OnButtonSouthCanceled -= ButtonSouthCanceled;
    }
    
    //Input event handlers
    private void LeftStick(Vector2 input)
    {
        leftStickInput = input;
    }
    
    private void ButtonSouth()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
       
    }
    
    #endregion

    private void Awake(){
        inputHandler = GetComponent<InputHandler>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from Unity's default horizontal and vertical axes
        float moveHorizontal = leftStickInput.x;
        float moveVertical   = leftStickInput.y;

        // Calculate movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed;

        // Preserve current y-velocity (so jump velocity is maintained)
        Vector3 newVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        rb.linearVelocity = newVelocity;

        // Apply additional gravity when falling
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (gravityMultiplier - 1) * Time.deltaTime;
        }

        // Jump if player presses Space and the capsule is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Check if we are colliding with the ground, assuming the ground is tagged "Ground"
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // If we leave the ground, we can no longer jump
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}