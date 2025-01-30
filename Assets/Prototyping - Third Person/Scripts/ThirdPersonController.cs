using System;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public InputHandler inputHandler; // Reference to the inputHandler script
    private Vector2 leftStickInput;    // Vector2 to store the left stick input
    
    public Camera GameCamera;
    public float playerSpeed = 5.0f;
    private float runSpeed;
    public bool running = false;
    private float JumpForce = 1.0f;
    
    private CharacterController m_Controller;
    private Animator m_Animator;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    private float gravityValue = -9.81f;
    
    #region inputHandler Events Subscription
    private void OnEnable() {
        // Subscribe to inputHandler events
        inputHandler.OnLeftStick += LeftStick;
        inputHandler.OnLeftStickCanceled += LeftStickedCanceled;
        inputHandler.OnButtonSouth += Jump;
        inputHandler.OnLeftTriggerPressed += Run;
        inputHandler.OnLeftTriggerReleased += Run;
    }
    private void OnDisable() {
        // Unsubscribe from inputHandler events
        inputHandler.OnLeftStick -= LeftStick;
        inputHandler.OnLeftStickCanceled -= LeftStickedCanceled;
        inputHandler.OnButtonSouth -= Jump;
        inputHandler.OnLeftTriggerPressed -= Run;
        inputHandler.OnLeftTriggerReleased -= Run;
    }
    //Input event handlers
    private void LeftStick(Vector2 input) {
        leftStickInput = input;
    }
    private void LeftStickedCanceled() {
        leftStickInput = Vector2.zero;
    }
 
    #endregion
    
    private void Start() {
        m_Controller = gameObject.GetComponent<CharacterController>();
        m_Animator = gameObject.GetComponentInChildren<Animator>();
        
        runSpeed = playerSpeed * 2;
    }

    void Update()
    {
        groundedPlayer = m_Controller.isGrounded;
        
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -0.5f;
        }

        Vector3 input = new Vector3(leftStickInput.x, 0, leftStickInput.y);

        //trasnform input into camera space
        var forward = GameCamera.transform.forward;
        forward.y = 0;
        forward.Normalize();
        var right = Vector3.Cross(Vector3.up, forward);
        
        Vector3 move = forward * input.z + right * input.x;
        move.y = 0;

        if (running)
        {
            m_Controller.Move(move * Time.deltaTime * runSpeed);
        }
        else
        {
            m_Controller.Move(move * Time.deltaTime * playerSpeed);
        }
        

        m_Animator.SetFloat("MovementX", input.x);
        m_Animator.SetFloat("MovementZ", input.z);

        if (input != Vector3.zero) {
            gameObject.transform.forward = forward;
        }
        
        //jumping 
        playerVelocity.y += gravityValue * Time.deltaTime;

        m_Controller.Move(playerVelocity * Time.deltaTime ) ;
        
    }

    private void Run()
    {
        running=!running;
    }
    private void Jump() {
        if (groundedPlayer) {
            playerVelocity.y += Mathf.Sqrt(JumpForce * -3.0f * gravityValue);
            m_Animator.SetTrigger("Jump");
        }
    }
}