using UnityEngine;

public class InputDebugger : MonoBehaviour
{
    public InputHandler inputHandler; // Reference to the inputHandler script
    
    [SerializeField] private bool debugAnalogInputs = true; // Toggle for analog input debug messages
    [SerializeField] private bool debugButtonInputs = true; // Toggle for button input debug messages
    
    #region inputHandler Events Subscription
    private void OnEnable()
    {
        // Subscribe to inputHandler events
        inputHandler.OnLeftStick += LeftStick;
        inputHandler.OnRightStick += RightStick;
        inputHandler.OnButtonSouth += ButtonSouth;
        inputHandler.OnButtonWest += ButtonWest;
        inputHandler.OnButtonNorth += ButtonNorth;
        inputHandler.OnButtonEast += ButtonEast;
        inputHandler.OnLeftTrigger += LeftTrigger;
        inputHandler.OnRightTrigger += RightTrigger;
        inputHandler.OnLeftTriggerPressed += LeftTriggerPress;
        inputHandler.OnRightTriggerPressed += RightTriggerPress;
        inputHandler.OnLeftShoulder += LeftShoulder;
        inputHandler.OnRightShoulder += RightShoulder;
        inputHandler.OnLeftStickPress += LeftStickPress;
        inputHandler.OnRightStickPress += RightStickPress;
        inputHandler.OnPadLeft += PadLeft;
        inputHandler.OnPadRight += PadRight;
        inputHandler.OnPadUp += PadUp;
        inputHandler.OnPadDown += PadDown;
        inputHandler.OnLeftStickLeft += LeftStickLeft;
        inputHandler.OnLeftStickRight += LeftStickRight;
        inputHandler.OnLeftStickUp += LeftStickUp;
        inputHandler.OnLeftStickDown += LeftStickDown;
        inputHandler.OnRightStickLeft += RightStickLeft;
        inputHandler.OnRightStickRight += RightStickRight;
        inputHandler.OnRightStickUp += RightStickUp;
        inputHandler.OnRightStickDown += RightStickDown;
        inputHandler.OnButtonStart += ButtonStart;
        inputHandler.OnButtonSelect += ButtonSelect;

        // Subscribe to canceled events
        inputHandler.OnLeftStickCanceled += LeftStickCanceled;
        inputHandler.OnRightStickCanceled += RightStickCanceled;
        inputHandler.OnButtonSouthCanceled += ButtonSouthCanceled;
        inputHandler.OnButtonWestCanceled += ButtonWestCanceled;
        inputHandler.OnButtonNorthCanceled += ButtonNorthCanceled;
        inputHandler.OnButtonEastCanceled += ButtonEastCanceled;
        inputHandler.OnLeftTriggerCanceled += LeftTriggerCanceled;
        inputHandler.OnRightTriggerCanceled += RightTriggerCanceled;
        inputHandler.OnLeftTriggerReleased += LeftTriggerReleased;
        inputHandler.OnRightTriggerReleased += RightTriggerReleased;
        inputHandler.OnLeftShoulderCanceled += LeftShoulderCanceled;
        inputHandler.OnRightShoulderCanceled += RightShoulderCanceled;
        inputHandler.OnLeftStickPressCanceled += LeftStickPressCanceled;
        inputHandler.OnRightStickPressCanceled += RightStickPressCanceled;
        inputHandler.OnPadLeftCanceled += PadLeftCanceled;
        inputHandler.OnPadRightCanceled += PadRightCanceled;
        inputHandler.OnPadUpCanceled += PadUpCanceled;
        inputHandler.OnPadDownCanceled += PadDownCanceled;
        inputHandler.OnLeftStickLeftCanceled += LeftStickLeftCanceled;
        inputHandler.OnLeftStickRightCanceled += LeftStickRightCanceled;
        inputHandler.OnLeftStickUpCanceled += LeftStickUpCanceled;
        inputHandler.OnLeftStickDownCanceled += LeftStickDownCanceled;
        inputHandler.OnRightStickLeftCanceled += RightStickLeftCanceled;
        inputHandler.OnRightStickRightCanceled += RightStickRightCanceled;
        inputHandler.OnRightStickUpCanceled += RightStickUpCanceled;
        inputHandler.OnRightStickDownCanceled += RightStickDownCanceled;
        inputHandler.OnButtonStartCanceled += ButtonStartCanceled;
        inputHandler.OnButtonSelectCanceled += ButtonSelectCanceled;
    }

    private void OnDisable()
    {
        // Unsubscribe from inputHandler events
        inputHandler.OnLeftStick -= LeftStick;
        inputHandler.OnRightStick -= RightStick;
        inputHandler.OnButtonSouth -= ButtonSouth;
        inputHandler.OnButtonWest -= ButtonWest;
        inputHandler.OnButtonNorth -= ButtonNorth;
        inputHandler.OnButtonEast -= ButtonEast;
        inputHandler.OnLeftTrigger -= LeftTrigger;
        inputHandler.OnRightTrigger -= RightTrigger;
        inputHandler.OnLeftTriggerPressed -= LeftTriggerPress;
        inputHandler.OnRightTriggerPressed -= RightTriggerPress;
        inputHandler.OnLeftShoulder -= LeftShoulder;
        inputHandler.OnRightShoulder -= RightShoulder;
        inputHandler.OnLeftStickPress -= LeftStickPress;
        inputHandler.OnRightStickPress -= RightStickPress;
        inputHandler.OnPadLeft -= PadLeft;
        inputHandler.OnPadRight -= PadRight;
        inputHandler.OnPadUp -= PadUp;
        inputHandler.OnPadDown -= PadDown;
        inputHandler.OnLeftStickLeft -= LeftStickLeft;
        inputHandler.OnLeftStickRight -= LeftStickRight;
        inputHandler.OnLeftStickUp -= LeftStickUp;
        inputHandler.OnLeftStickDown -= LeftStickDown;
        inputHandler.OnRightStickLeft -= RightStickLeft;
        inputHandler.OnRightStickRight -= RightStickRight;
        inputHandler.OnRightStickUp -= RightStickUp;
        inputHandler.OnRightStickDown -= RightStickDown;
        inputHandler.OnButtonStart -= ButtonStart;
        inputHandler.OnButtonSelect -= ButtonSelect;

        // Unsubscribe from canceled events
        inputHandler.OnLeftStickCanceled -= LeftStickCanceled;
        inputHandler.OnRightStickCanceled -= RightStickCanceled;
        inputHandler.OnButtonSouthCanceled -= ButtonSouthCanceled;
        inputHandler.OnButtonWestCanceled -= ButtonWestCanceled;
        inputHandler.OnButtonNorthCanceled -= ButtonNorthCanceled;
        inputHandler.OnButtonEastCanceled -= ButtonEastCanceled;
        inputHandler.OnLeftTriggerCanceled -= LeftTriggerCanceled;
        inputHandler.OnRightTriggerCanceled -= RightTriggerCanceled;
        inputHandler.OnLeftTriggerReleased -= LeftTriggerReleased;
        inputHandler.OnRightTriggerReleased -= RightTriggerReleased;
        inputHandler.OnLeftShoulderCanceled -= LeftShoulderCanceled;
        inputHandler.OnRightShoulderCanceled -= RightShoulderCanceled;
        inputHandler.OnLeftStickPressCanceled -= LeftStickPressCanceled;
        inputHandler.OnRightStickPressCanceled -= RightStickPressCanceled;
        inputHandler.OnPadLeftCanceled -= PadLeftCanceled;
        inputHandler.OnPadRightCanceled -= PadRightCanceled;
        inputHandler.OnPadUpCanceled -= PadUpCanceled;
        inputHandler.OnPadDownCanceled -= PadDownCanceled;
        inputHandler.OnLeftStickLeftCanceled -= LeftStickLeftCanceled;
        inputHandler.OnLeftStickRightCanceled -= LeftStickRightCanceled;
        inputHandler.OnLeftStickUpCanceled -= LeftStickUpCanceled;
        inputHandler.OnLeftStickDownCanceled -= LeftStickDownCanceled;
        inputHandler.OnRightStickLeftCanceled -= RightStickLeftCanceled;
        inputHandler.OnRightStickRightCanceled -= RightStickRightCanceled;
        inputHandler.OnRightStickUpCanceled -= RightStickUpCanceled;
        inputHandler.OnRightStickDownCanceled -= RightStickDownCanceled;
        inputHandler.OnButtonStartCanceled -= ButtonStartCanceled;
        inputHandler.OnButtonSelectCanceled -= ButtonSelectCanceled;
    }
    #endregion

    void Awake()
    {
        if(gameObject.GetComponent<InputHandler>() && inputHandler == null)
        {
            inputHandler = gameObject.GetComponent<InputHandler>();
        }

    }
    
    private void DebugLog(string message, bool isAnalog)
    {
        if ((isAnalog && debugAnalogInputs) || (!isAnalog && debugButtonInputs))
        {
            Debug.Log(message);
        }
    }

    //Input event handlers
    private void LeftStick(Vector2 input)
    {
        DebugLog($"LeftStick with input: {input}", true);
    }

    private void RightStick(Vector2 input)
    {
        DebugLog($"RightStick with input: {input}", true);
    }

    private void ButtonSouth()
    {
        DebugLog("ButtonSouth pressed!", false);
    }

    private void ButtonWest()
    {
        DebugLog("ButtonWest pressed!", false);
    }

    private void ButtonNorth()
    {
        DebugLog("ButtonNorth pressed!", false);
    }

    private void ButtonEast()
    {
        DebugLog("ButtonEast pressed!", false);
    }

    private void LeftTrigger(float input)
    {
        DebugLog($"LeftTrigger with input: {input}", true);
    }

    private void RightTrigger(float input)
    {
        DebugLog($"RightTrigger with input: {input}", true);
    }
    
    private void LeftTriggerPress()
    {
        DebugLog("LeftTrigger pressed!", false);
    }
    
    private void RightTriggerPress()
    {
        DebugLog("RightTrigger pressed!", false);
    }

    private void LeftShoulder()
    {
        DebugLog("LeftShoulder pressed!", false);
    }

    private void RightShoulder()
    {
        DebugLog("RightShoulder pressed!", false);
    }

    private void LeftStickPress()
    {
        DebugLog("LeftStickPress pressed!", false);
    }

    private void RightStickPress()
    {
        DebugLog("RightStickPress pressed!", false);
    }

    private void PadLeft()
    {
        DebugLog("PadLeft pressed!", false);
    }

    private void PadRight()
    {
        DebugLog("PadRight pressed!", false);
    }

    private void PadUp()
    {
        DebugLog("PadUp pressed!", false);
    }

    private void PadDown()
    {
        DebugLog("PadDown pressed!", false);
    }

    private void LeftStickLeft()
    {
        DebugLog("LeftStickLeft pressed!", false);
    }

    private void LeftStickRight()
    {
        DebugLog("LeftStickRight pressed!", false);
    }

    private void LeftStickUp()
    {
        DebugLog("LeftStickUp pressed!", false);
    }

    private void LeftStickDown()
    {
        DebugLog("LeftStickDown pressed!", false);
    }

    private void RightStickLeft()
    {
        DebugLog("RightStickLeft pressed!", false);
    }

    private void RightStickRight()
    {
        DebugLog("RightStickRight pressed!", false);
    }

    private void RightStickUp()
    {
        DebugLog("RightStickUp pressed!", false);
    }

    private void RightStickDown()
    {
        DebugLog("RightStickDown pressed!", false);
    }

    private void ButtonStart()
    {
        DebugLog("ButtonStart pressed!", false);
    }

    private void ButtonSelect()
    {
        DebugLog("ButtonSelect pressed!", false);
    }

    // Canceled event handlers
    private void LeftStickCanceled()
    {
        DebugLog("LeftStick canceled!", true);
    }

    private void RightStickCanceled()
    {
        DebugLog("RightStick canceled!", true);
    }

    private void ButtonSouthCanceled()
    {
        DebugLog("ButtonSouth canceled!", false);
    }

    private void ButtonWestCanceled()
    {
        DebugLog("ButtonWest canceled!", false);
    }

    private void ButtonNorthCanceled()
    {
        DebugLog("ButtonNorth canceled!", false);
    }

    private void ButtonEastCanceled()
    {
        DebugLog("ButtonEast canceled!", false);
    }

    private void LeftTriggerCanceled()
    {
        DebugLog("LeftTrigger canceled!", false);
    }

    private void RightTriggerCanceled()
    {
        DebugLog("RightTrigger canceled!", false);
    }
    
    private void LeftTriggerReleased()
    {
        DebugLog("LeftTrigger released!", false);
    }
    
    private void RightTriggerReleased()
    {
        DebugLog("RightTrigger released!", false);
    }

    private void LeftShoulderCanceled()
    {
        DebugLog("LeftShoulder canceled!", false);
    }

    private void RightShoulderCanceled()
    {
        DebugLog("RightShoulder canceled!", false);
    }

    private void LeftStickPressCanceled()
    {
        DebugLog("LeftStickPress canceled!", false);
    }

    private void RightStickPressCanceled()
    {
        DebugLog("RightStickPress canceled!", false);
    }

    private void PadLeftCanceled()
    {
        DebugLog("PadLeft canceled!", false);
    }

    private void PadRightCanceled()
    {
        DebugLog("PadRight canceled!", false);
    }

    private void PadUpCanceled()
    {
        DebugLog("PadUp canceled!", false);
    }

    private void PadDownCanceled()
    {
        DebugLog("PadDown canceled!", false);
    }

    private void LeftStickLeftCanceled()
    {
        DebugLog("LeftStickLeft canceled!", false);
    }

    private void LeftStickRightCanceled()
    {
        DebugLog("LeftStickRight canceled!", false);
    }

    private void LeftStickUpCanceled()
    {
        DebugLog("LeftStickUp canceled!", false);
    }

    private void LeftStickDownCanceled()
    {
        DebugLog("LeftStickDown canceled!", false);
    }

    private void RightStickLeftCanceled()
    {
        DebugLog("RightStickLeft canceled!", false);
    }

    private void RightStickRightCanceled()
    {
        DebugLog("RightStickRight canceled!", false);
    }

    private void RightStickUpCanceled()
    {
        DebugLog("RightStickUp canceled!", false);
    }

    private void RightStickDownCanceled()
    {
        DebugLog("RightStickDown canceled!", false);
    }

    private void ButtonStartCanceled()
    {
        DebugLog("ButtonStart canceled!", false);
    }

    private void ButtonSelectCanceled()
    {
        DebugLog("ButtonSelect canceled!", false);
    }
}