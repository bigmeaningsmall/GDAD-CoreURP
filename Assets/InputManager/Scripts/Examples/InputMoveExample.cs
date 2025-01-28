using UnityEngine;

/// <summary>
/// This script is an example of how to use the InputHandler script to move a GameObject using the left stick input.
/// It requires a Rigidbody component to work.
/// It is just a basic example and can be expanded upon to include more complex movement mechanics. 
/// </summary>

[RequireComponent(typeof(Rigidbody))]
public class InputMoveExample : MonoBehaviour
{
    public InputHandler inputHandler; // Reference to the inputHandler script
    
    private Vector2 leftStickInput;    // Vector2 to store the left stick input
    
    [Header("Movement Settings")]
    public float moveSpeed = 5f;      // Speed of movement on the plane

    private Rigidbody rb;
    
    #region inputHandler Events Subscription
    private void OnEnable()
    {
        // Subscribe to inputHandler events
        inputHandler.OnLeftStick += LeftStick;
    }

    private void OnDisable()
    {
        // Unsubscribe from inputHandler events
        inputHandler.OnLeftStick -= LeftStick;
    }
    
    //Input event handlers
    private void LeftStick(Vector2 input)
    {
        leftStickInput = input;
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
        // Get input from Unity's default horizontal and vertical axes
        float moveHorizontal = leftStickInput.x;
        float moveVertical   = leftStickInput.y;

        // Calculate movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed;
        
        // Preserve current y-velocity (so jump velocity is maintained)
        Vector3 newVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        rb.linearVelocity = newVelocity;
    }
    #endregion

}