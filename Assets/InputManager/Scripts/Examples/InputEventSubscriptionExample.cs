using UnityEngine;

public class InputEventSubscriptionExample : MonoBehaviour{
    public InputHandler inputHandler; // Reference to the inputHandler script

    [SerializeField] Vector2 leftStickInput; // Vector2 to store the left stick input
    [SerializeField] Vector2 rightStickInput; // Vector2 to store the right stick input
    [SerializeField] bool buttonSouth; // Boolean to store the button south input
    [SerializeField] bool buttonWest; // Boolean to store the button west input
    [SerializeField] bool buttonNorth; // Boolean to store the button north input
    [SerializeField] bool buttonEast; // Boolean to store the button east input
    [SerializeField] float leftTrigger; // Float to store the left trigger input   
    [SerializeField] float rightTrigger; // Float to store the right trigger input
    [SerializeField] bool leftShoulder; // Boolean to store the left shoulder input
    [SerializeField] bool rightShoulder; // Boolean to store the right shoulder input

    #region inputHandler Events Subscription

    private void OnEnable(){
        // Subscribe to inputHandler events
        inputHandler.OnLeftStick += LeftStick;
        inputHandler.OnRightStick += RightStick;
        inputHandler.OnButtonSouth += ButtonSouth;
        inputHandler.OnButtonWest += ButtonWest;
        inputHandler.OnButtonNorth += ButtonNorth;
        inputHandler.OnButtonEast += ButtonEast;
        inputHandler.OnLeftTrigger += LeftTrigger;
        inputHandler.OnRightTrigger += RightTrigger;
        inputHandler.OnLeftShoulder += LeftShoulder;
        inputHandler.OnRightShoulder += RightShoulder;

        // Subscribe to InputHandler canceled events if needed
        // (these are optional but can be useful for certain situations like UI navigation, resetting values, releasing held objects, etc.)
        inputHandler.OnLeftStickCanceled += LeftStickCanceled;
        inputHandler.OnRightStickCanceled += RightStickCanceled;
        inputHandler.OnButtonSouthCanceled += ButtonSouthCanceled;
        inputHandler.OnButtonWestCanceled += ButtonWestCanceled;
        inputHandler.OnButtonNorthCanceled += ButtonNorthCanceled;
        inputHandler.OnButtonEastCanceled += ButtonEastCanceled;
        inputHandler.OnLeftTriggerCanceled += LeftTriggerCanceled;
        inputHandler.OnRightTriggerCanceled += RightTriggerCanceled;
        inputHandler.OnLeftShoulderCanceled += LeftShoulderCanceled;
        inputHandler.OnRightShoulderCanceled += RightShoulderCanceled;
    }

    private void OnDisable(){
        // Unsubscribe from inputHandler events
        inputHandler.OnLeftStick -= LeftStick;
        inputHandler.OnRightStick -= RightStick;
        inputHandler.OnButtonSouth -= ButtonSouth;
        inputHandler.OnButtonWest -= ButtonWest;
        inputHandler.OnButtonNorth -= ButtonNorth;
        inputHandler.OnButtonEast -= ButtonEast;
        inputHandler.OnLeftTrigger -= LeftTrigger;
        inputHandler.OnRightTrigger -= RightTrigger;
        inputHandler.OnLeftShoulder -= LeftShoulder;
        inputHandler.OnRightShoulder -= RightShoulder;

        // Unsubscribe from InputHandler canceled events if needed
        inputHandler.OnLeftStickCanceled -= LeftStickCanceled;
        inputHandler.OnRightStickCanceled -= RightStickCanceled;
        inputHandler.OnButtonSouthCanceled -= ButtonSouthCanceled;
        inputHandler.OnButtonWestCanceled -= ButtonWestCanceled;
        inputHandler.OnButtonNorthCanceled -= ButtonNorthCanceled;
        inputHandler.OnButtonEastCanceled -= ButtonEastCanceled;
        inputHandler.OnLeftTriggerCanceled -= LeftTriggerCanceled;
        inputHandler.OnRightTriggerCanceled -= RightTriggerCanceled;
        inputHandler.OnLeftShoulderCanceled -= LeftShoulderCanceled;
        inputHandler.OnRightShoulderCanceled -= RightShoulderCanceled;
    }

    #endregion

    #region Initialise

    void Awake(){
        if (gameObject.GetComponent<InputHandler>() && inputHandler == null){
            inputHandler = gameObject.GetComponent<InputHandler>();
        }
    }

    #endregion

    #region Input Handling Functions

    //Input event handlers
    private void LeftStick(Vector2 input){
        leftStickInput = input;
    }

    private void RightStick(Vector2 input){
        rightStickInput = input;
    }

    private void ButtonSouth(){
        buttonSouth = true;
    }

    private void ButtonWest(){
        buttonWest = true;
    }

    private void ButtonNorth(){
        buttonNorth = true;
    }

    private void ButtonEast(){
        buttonEast = true;
    }

    private void LeftTrigger(float input){
        leftTrigger = input;
    }

    private void RightTrigger(float input){
        rightTrigger = input;
    }

    private void LeftShoulder(){
        leftShoulder = true;
    }

    private void RightShoulder(){
        rightShoulder = true;
    }

    #endregion


    #region Input Handling Cencelled Functions

    //Input event handlers for canceled events (Optional but helpful for certain situations and resetting values)

    private void LeftStickCanceled(){
        leftStickInput = Vector2.zero;
    }

    private void RightStickCanceled(){
        rightStickInput = Vector2.zero;
    }

    private void ButtonSouthCanceled(){
        buttonSouth = false;
    }

    private void ButtonWestCanceled(){
        buttonWest = false;
    }

    private void ButtonNorthCanceled(){
        buttonNorth = false;
    }

    private void ButtonEastCanceled(){
        buttonEast = false;
    }

    private void LeftTriggerCanceled(){
        leftTrigger = 0f;
    }

    private void RightTriggerCanceled(){
        rightTrigger = 0f;
    }

    private void LeftShoulderCanceled(){
        leftShoulder = false;
    }

    private void RightShoulderCanceled(){
        rightShoulder = false;
    }

    #endregion
}