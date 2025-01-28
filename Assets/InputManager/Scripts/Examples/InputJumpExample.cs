using System;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
///  This script is an example of how to use the InputHandler script to jump a GameObject using the button south input.
///  It requires a Rigidbody component to work.
///  It is just a basic example and can be expanded upon to include more complex jump or similar mechanics.
/// </summary>

[RequireComponent(typeof(Rigidbody))]
public class InputJumpExample : MonoBehaviour
{
    public InputHandler inputHandler; // Reference to the inputHandler script
    private bool buttonSouth;           // Boolean to store the button south input
    
    [Header("Jump Settings")]
    public float jumpForce = 5f;      // Upward force applied for jumps
    public float positiveGravityMultiplier = 2f; // Multiplier for gravity when falling
    public float negativeGravityMultiplier = 3f; // Multiplier for gravity when falling

    private Rigidbody rb;
    private bool isGrounded;
    
    #region inputHandler Events Subscription
    private void OnEnable()
    {
        // Subscribe to inputHandler events
        inputHandler.OnButtonSouth += ButtonSouth;
    }

    private void OnDisable()
    {
        // Unsubscribe from inputHandler events
        inputHandler.OnButtonSouth -= ButtonSouth;
    }
    
    //Input event handlers
    private void ButtonSouth()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
       
    }
    
    #endregion

    #region Initialise
    private void Awake(){
        if(this.gameObject.GetComponent<InputHandler>() == null){
            this.gameObject.AddComponent<InputHandler>();
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    #endregion

    #region Update Methods

    void Update()
    {
        // Apply additional gravity when falling or rising
        JumpGravity();
        
    }
    
    private void JumpGravity()
    {
        // Apply additional gravity when falling or rising
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (negativeGravityMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (positiveGravityMultiplier - 1) * Time.deltaTime;
        }
    }

    #endregion

    #region Collision Methods
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
    #endregion


}