using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputHandler : MonoBehaviour
{
    // Define static events for input actions
    public event Action<Vector2> OnLeftStick;
    public event Action OnLeftStickCanceled;
    public event Action<Vector2> OnRightStick;
    public event Action OnRightStickCanceled;
    public event Action OnButtonNorth;
    public event Action OnButtonNorthCanceled;
    public event Action OnButtonSouth;
    public event Action OnButtonSouthCanceled;
    public event Action OnButtonEast;
    public event Action OnButtonEastCanceled;
    public event Action OnButtonWest;
    public event Action OnButtonWestCanceled;
    public event Action<float> OnLeftTrigger;
    public event Action OnLeftTriggerCanceled;
    public event Action<float> OnRightTrigger;
    public event Action OnRightTriggerCanceled;
    public event Action OnLeftTriggerPressed;
    public event Action OnLeftTriggerReleased;
    public event Action OnRightTriggerPressed;
    public event Action OnRightTriggerReleased;
    public event Action OnLeftShoulder;
    public event Action OnLeftShoulderCanceled;
    public event Action OnRightShoulder;
    public event Action OnRightShoulderCanceled;
    public event Action OnLeftStickPress;
    public event Action OnLeftStickPressCanceled;
    public event Action OnRightStickPress;
    public event Action OnRightStickPressCanceled;
    public event Action OnPadLeft;
    public event Action OnPadLeftCanceled;
    public event Action OnPadRight;
    public event Action OnPadRightCanceled;
    public event Action OnPadUp;
    public event Action OnPadUpCanceled;
    public event Action OnPadDown;
    public event Action OnPadDownCanceled;
    public event Action OnLeftStickLeft;
    public event Action OnLeftStickLeftCanceled;
    public event Action OnLeftStickRight;
    public event Action OnLeftStickRightCanceled;
    public event Action OnLeftStickUp;
    public event Action OnLeftStickUpCanceled;
    public event Action OnLeftStickDown;
    public event Action OnLeftStickDownCanceled;
    public event Action OnRightStickLeft;
    public event Action OnRightStickLeftCanceled;
    public event Action OnRightStickRight;
    public event Action OnRightStickRightCanceled;
    public event Action OnRightStickUp;
    public event Action OnRightStickUpCanceled;
    public event Action OnRightStickDown;
    public event Action OnRightStickDownCanceled;
    public event Action OnButtonStart;
    public event Action OnButtonStartCanceled;
    public event Action OnButtonSelect;
    public event Action OnButtonSelectCanceled;

    // Reference to the Input Actions asset
    [SerializeField] private InputActionAsset inputActions;

    // Cached input actions
    private InputAction leftStickAction;
    private InputAction rightStickAction;

    private InputAction buttonNorthAction;
    private InputAction buttonSouthAction;
    private InputAction buttonEastAction;
    private InputAction buttonWestAction;

    private InputAction leftTriggerAction;
    private InputAction rightTriggerAction;
    private InputAction leftTriggerPressedAction;
    private InputAction rightTriggerPressedAction;

    private InputAction leftShoulderAction;
    private InputAction rightShoulderAction;

    private InputAction leftStickPressAction;
    private InputAction rightStickPressAction;

    private InputAction padLeftAction;
    private InputAction padRightAction;
    private InputAction padUpAction;
    private InputAction padDownAction;

    private InputAction leftStickLeftAction;
    private InputAction leftStickRightAction;
    private InputAction leftStickUpAction;
    private InputAction leftStickDownAction;
    private InputAction rightStickLeftAction;
    private InputAction rightStickRightAction;
    private InputAction rightStickUpAction;
    private InputAction rightStickDownAction;

    private InputAction buttonStartAction;
    private InputAction buttonSelectAction;

    private void Awake()
    {
        // Get individual input actions
        var playerInputMap = inputActions.FindActionMap("Player"); // Replace "Player" with your action map name

        leftStickAction = playerInputMap.FindAction("LeftStick");
        rightStickAction = playerInputMap.FindAction("RightStick");

        buttonWestAction = playerInputMap.FindAction("ButtonWest");
        buttonSouthAction = playerInputMap.FindAction("ButtonSouth");
        buttonNorthAction = playerInputMap.FindAction("ButtonNorth");
        buttonEastAction = playerInputMap.FindAction("ButtonEast");

        leftTriggerAction = playerInputMap.FindAction("LeftTrigger");
        rightTriggerAction = playerInputMap.FindAction("RightTrigger");
        leftTriggerPressedAction = playerInputMap.FindAction("LeftTriggerPress");
        rightTriggerPressedAction = playerInputMap.FindAction("RightTriggerPress");

        leftShoulderAction = playerInputMap.FindAction("LeftShoulder");
        rightShoulderAction = playerInputMap.FindAction("RightShoulder");
        leftStickPressAction = playerInputMap.FindAction("LeftStickPress");
        rightStickPressAction = playerInputMap.FindAction("RightStickPress");

        padLeftAction = playerInputMap.FindAction("PadLeft");
        padRightAction = playerInputMap.FindAction("PadRight");
        padUpAction = playerInputMap.FindAction("PadUp");
        padDownAction = playerInputMap.FindAction("PadDown");

        leftStickLeftAction = playerInputMap.FindAction("LeftStickLeft");
        leftStickRightAction = playerInputMap.FindAction("LeftStickRight");
        leftStickUpAction = playerInputMap.FindAction("LeftStickUp");
        leftStickDownAction = playerInputMap.FindAction("LeftStickDown");
        rightStickLeftAction = playerInputMap.FindAction("RightStickLeft");
        rightStickRightAction = playerInputMap.FindAction("RightStickRight");
        rightStickUpAction = playerInputMap.FindAction("RightStickUp");
        rightStickDownAction = playerInputMap.FindAction("RightStickDown");

        buttonStartAction = playerInputMap.FindAction("ButtonStart");
        buttonSelectAction = playerInputMap.FindAction("ButtonSelect");
    }

    private void OnEnable()
    {
        // Enable input actions
        leftStickAction.Enable();
        rightStickAction.Enable();
        buttonWestAction.Enable();
        buttonSouthAction.Enable();
        buttonNorthAction.Enable();
        buttonEastAction.Enable();
        leftTriggerAction.Enable();
        rightTriggerAction.Enable();
        leftTriggerPressedAction.Enable();
        rightTriggerPressedAction.Enable();
        leftShoulderAction.Enable();
        rightShoulderAction.Enable();
        leftStickPressAction.Enable();
        rightStickPressAction.Enable();
        padLeftAction.Enable();
        padRightAction.Enable();
        padUpAction.Enable();
        padDownAction.Enable();
        leftStickLeftAction.Enable();
        leftStickRightAction.Enable();
        leftStickUpAction.Enable();
        leftStickDownAction.Enable();
        rightStickLeftAction.Enable();
        rightStickRightAction.Enable();
        rightStickUpAction.Enable();
        rightStickDownAction.Enable();
        buttonStartAction.Enable();
        buttonSelectAction.Enable();

        // Subscribe to input action callbacks
        leftStickAction.performed += HandleLeftStick;
        leftStickAction.canceled += HandleLeftStickCanceled;
        rightStickAction.performed += HandleRightStick;
        rightStickAction.canceled += HandleRightStickCanceled;
        buttonWestAction.performed += HandleButtonWest;
        buttonWestAction.canceled += HandleButtonWestCanceled;
        buttonSouthAction.performed += HandleButtonSouth;
        buttonSouthAction.canceled += HandleButtonSouthCanceled;
        buttonNorthAction.performed += HandleButtonNorth;
        buttonNorthAction.canceled += HandleButtonNorthCanceled;
        buttonEastAction.performed += HandleButtonEast;
        buttonEastAction.canceled += HandleButtonEastCanceled;
        leftTriggerAction.performed += HandleLeftTrigger;
        leftTriggerAction.canceled += HandleLeftTriggerCanceled;
        rightTriggerAction.performed += HandleRightTrigger;
        rightTriggerAction.canceled += HandleRightTriggerCanceled;
        leftTriggerPressedAction.performed += HandleLeftTriggerPressed;
        rightTriggerPressedAction.performed += HandleRightTriggerPressed;
        leftShoulderAction.performed += HandleLeftShoulder;
        leftShoulderAction.canceled += HandleLeftShoulderCanceled;
        rightShoulderAction.performed += HandleRightShoulder;
        rightShoulderAction.canceled += HandleRightShoulderCanceled;
        leftStickPressAction.performed += HandleLeftStickPress;
        leftStickPressAction.canceled += HandleLeftStickPressCanceled;
        rightStickPressAction.performed += HandleRightStickPress;
        rightStickPressAction.canceled += HandleRightStickPressCanceled;
        padLeftAction.performed += HandlePadLeft;
        padLeftAction.canceled += HandlePadLeftCanceled;
        padRightAction.performed += HandlePadRight;
        padRightAction.canceled += HandlePadRightCanceled;
        padUpAction.performed += HandlePadUp;
        padUpAction.canceled += HandlePadUpCanceled;
        padDownAction.performed += HandlePadDown;
        padDownAction.canceled += HandlePadDownCanceled;
        leftStickLeftAction.performed += HandleLeftStickLeft;
        leftStickLeftAction.canceled += HandleLeftStickLeftCanceled;
        leftStickRightAction.performed += HandleLeftStickRight;
        leftStickRightAction.canceled += HandleLeftStickRightCanceled;
        leftStickUpAction.performed += HandleLeftStickUp;
        leftStickUpAction.canceled += HandleLeftStickUpCanceled;
        leftStickDownAction.performed += HandleLeftStickDown;
        leftStickDownAction.canceled += HandleLeftStickDownCanceled;
        rightStickLeftAction.performed += HandleRightStickLeft;
        rightStickLeftAction.canceled += HandleRightStickLeftCanceled;
        rightStickRightAction.performed += HandleRightStickRight;
        rightStickRightAction.canceled += HandleRightStickRightCanceled;
        rightStickUpAction.performed += HandleRightStickUp;
        rightStickUpAction.canceled += HandleRightStickUpCanceled;
        rightStickDownAction.performed += HandleRightStickDown;
        rightStickDownAction.canceled += HandleRightStickDownCanceled;
        buttonStartAction.performed += HandleButtonStart;
        buttonStartAction.canceled += HandleButtonStartCanceled;
        buttonSelectAction.performed += HandleButtonSelect;
        buttonSelectAction.canceled += HandleButtonSelectCanceled;
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        leftStickAction.performed -= HandleLeftStick;
        leftStickAction.canceled -= HandleLeftStickCanceled;
        rightStickAction.performed -= HandleRightStick;
        rightStickAction.canceled -= HandleRightStickCanceled;
        buttonWestAction.performed -= HandleButtonWest;
        buttonWestAction.canceled -= HandleButtonWestCanceled;
        buttonSouthAction.performed -= HandleButtonSouth;
        buttonSouthAction.canceled -= HandleButtonSouthCanceled;
        buttonNorthAction.performed -= HandleButtonNorth;
        buttonNorthAction.canceled -= HandleButtonNorthCanceled;
        buttonEastAction.performed -= HandleButtonEast;
        buttonEastAction.canceled -= HandleButtonEastCanceled;
        leftTriggerAction.performed -= HandleLeftTrigger;
        leftTriggerAction.canceled -= HandleLeftTriggerCanceled;
        rightTriggerAction.performed -= HandleRightTrigger;
        rightTriggerAction.canceled -= HandleRightTriggerCanceled;
        leftTriggerPressedAction.performed -= HandleLeftTriggerPressed;
        rightTriggerPressedAction.performed -= HandleRightTriggerPressed;
        leftShoulderAction.performed -= HandleLeftShoulder;
        leftShoulderAction.canceled -= HandleLeftShoulderCanceled;
        rightShoulderAction.performed -= HandleRightShoulder;
        rightShoulderAction.canceled -= HandleRightShoulderCanceled;
        leftStickPressAction.performed -= HandleLeftStickPress;
        leftStickPressAction.canceled -= HandleLeftStickPressCanceled;
        rightStickPressAction.performed -= HandleRightStickPress;
        rightStickPressAction.canceled -= HandleRightStickPressCanceled;
        padLeftAction.performed -= HandlePadLeft;
        padLeftAction.canceled -= HandlePadLeftCanceled;
        padRightAction.performed -= HandlePadRight;
        padRightAction.canceled -= HandlePadRightCanceled;
        padUpAction.performed -= HandlePadUp;
        padUpAction.canceled -= HandlePadUpCanceled;
        padDownAction.performed -= HandlePadDown;
        padDownAction.canceled -= HandlePadDownCanceled;
        leftStickLeftAction.performed -= HandleLeftStickLeft;
        leftStickLeftAction.canceled -= HandleLeftStickLeftCanceled;
        leftStickRightAction.performed -= HandleLeftStickRight;
        leftStickRightAction.canceled -= HandleLeftStickRightCanceled;
        leftStickUpAction.performed -= HandleLeftStickUp;
        leftStickUpAction.canceled -= HandleLeftStickUpCanceled;
        leftStickDownAction.performed -= HandleLeftStickDown;
        leftStickDownAction.canceled -= HandleLeftStickDownCanceled;
        rightStickLeftAction.performed -= HandleRightStickLeft;
        rightStickLeftAction.canceled -= HandleRightStickLeftCanceled;
        rightStickRightAction.performed -= HandleRightStickRight;
        rightStickRightAction.canceled -= HandleRightStickRightCanceled;
        rightStickUpAction.performed -= HandleRightStickUp;
        rightStickUpAction.canceled -= HandleRightStickUpCanceled;
        rightStickDownAction.performed -= HandleRightStickDown;
        rightStickDownAction.canceled -= HandleRightStickDownCanceled;
        buttonStartAction.performed -= HandleButtonStart;
        buttonStartAction.canceled -= HandleButtonStartCanceled;
        buttonSelectAction.performed -= HandleButtonSelect;
        buttonSelectAction.canceled -= HandleButtonSelectCanceled;

        // Disable input actions
        leftStickAction.Disable();
        rightStickAction.Disable();
        buttonWestAction.Disable();
        buttonSouthAction.Disable();
        buttonNorthAction.Disable();
        buttonEastAction.Disable();
        leftTriggerAction.Disable();
        rightTriggerAction.Disable();
        leftTriggerPressedAction.Disable();
        rightTriggerPressedAction.Disable();
        leftShoulderAction.Disable();
        rightShoulderAction.Disable();
        leftStickPressAction.Disable();
        rightStickPressAction.Disable();
        padLeftAction.Disable();
        padRightAction.Disable();
        padUpAction.Disable();
        padDownAction.Disable();
        leftStickLeftAction.Disable();
        leftStickRightAction.Disable();
        leftStickUpAction.Disable();
        leftStickDownAction.Disable();
        rightStickLeftAction.Disable();
        rightStickRightAction.Disable();
        rightStickUpAction.Disable();
        rightStickDownAction.Disable();
        buttonStartAction.Disable();
        buttonSelectAction.Disable();
    }

    // Input event handlers
    private void HandleLeftStick(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        OnLeftStick?.Invoke(input);
    }

    private void HandleRightStick(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        OnRightStick?.Invoke(input);
    }

    private void HandleButtonWest(InputAction.CallbackContext context)
    {
        OnButtonWest?.Invoke();
    }

    private void HandleButtonSouth(InputAction.CallbackContext context)
    {
        OnButtonSouth?.Invoke();
    }

    private void HandleButtonNorth(InputAction.CallbackContext context)
    {
        OnButtonNorth?.Invoke();
    }

    private void HandleButtonEast(InputAction.CallbackContext context)
    {
        OnButtonEast?.Invoke();
    }
    
    private void HandleLeftTrigger(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<float>();
        OnLeftTrigger?.Invoke(input);
    }
    
    private void HandleRightTrigger(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<float>();
        OnRightTrigger?.Invoke(input);
    }
    
    private void HandleLeftTriggerPressed(InputAction.CallbackContext context)
    {
        if (context.control.IsPressed())
        {
            OnLeftTriggerPressed?.Invoke();
        }
        else
        {
            OnLeftTriggerReleased?.Invoke();
        }
    }

    private void HandleRightTriggerPressed(InputAction.CallbackContext context)
    {
        if (context.control.IsPressed())
        {
            OnRightTriggerPressed?.Invoke();
        }
        else
        {
            OnRightTriggerReleased?.Invoke();
        }
    }
    
    private void HandleLeftShoulder(InputAction.CallbackContext context)
    {
        OnLeftShoulder?.Invoke();
    }
    
    private void HandleRightShoulder(InputAction.CallbackContext context)
    {
        OnRightShoulder?.Invoke();
    }
    
    private void HandleLeftStickPress(InputAction.CallbackContext context)
    {
        OnLeftStickPress?.Invoke();
    }
    
    private void HandleRightStickPress(InputAction.CallbackContext context)
    {
        OnRightStickPress?.Invoke();
    }
    
    private void HandlePadLeft(InputAction.CallbackContext context)
    {
        OnPadLeft?.Invoke();
    }
    
    private void HandlePadRight(InputAction.CallbackContext context)
    {
        OnPadRight?.Invoke();
    }
    
    private void HandlePadUp(InputAction.CallbackContext context)
    {
        OnPadUp?.Invoke();
    }
    
    private void HandlePadDown(InputAction.CallbackContext context)
    {
        OnPadDown?.Invoke();
    }
    
    private void HandleLeftStickLeft(InputAction.CallbackContext context)
    {
        OnLeftStickLeft?.Invoke();
    }
    
    private void HandleLeftStickRight(InputAction.CallbackContext context)
    {
        OnLeftStickRight?.Invoke();
    }
    
    private void HandleLeftStickUp(InputAction.CallbackContext context)
    {
        OnLeftStickUp?.Invoke();
    }
    
    private void HandleLeftStickDown(InputAction.CallbackContext context)
    {
        OnLeftStickDown?.Invoke();
    }
    
    private void HandleRightStickLeft(InputAction.CallbackContext context)
    {
        OnRightStickLeft?.Invoke();
    }
    
    private void HandleRightStickRight(InputAction.CallbackContext context)
    {
        OnRightStickRight?.Invoke();
    }
    
    private void HandleRightStickUp(InputAction.CallbackContext context)
    {
        OnRightStickUp?.Invoke();
    }
    
    private void HandleRightStickDown(InputAction.CallbackContext context)
    {
        OnRightStickDown?.Invoke();
    }
    
    private void HandleButtonStart(InputAction.CallbackContext context)
    {
        OnButtonStart?.Invoke();
    }
    
    private void HandleButtonSelect(InputAction.CallbackContext context)
    {
        OnButtonSelect?.Invoke();
    }
    
    // Input event handlers for canceled or released events
    private void HandleLeftStickCanceled(InputAction.CallbackContext context)
    {
        OnLeftStickCanceled?.Invoke();
    }
    
    private void HandleRightStickCanceled(InputAction.CallbackContext context)
    {
        OnRightStickCanceled?.Invoke();
    }
    
    private void HandleButtonWestCanceled(InputAction.CallbackContext context)
    {
        OnButtonWestCanceled?.Invoke();
    }
    
    private void HandleButtonSouthCanceled(InputAction.CallbackContext context)
    {
        OnButtonSouthCanceled?.Invoke();
    }
    
    private void HandleButtonNorthCanceled(InputAction.CallbackContext context)
    {
        OnButtonNorthCanceled?.Invoke();
    }
    
    private void HandleButtonEastCanceled(InputAction.CallbackContext context)
    {
        OnButtonEastCanceled?.Invoke();
    }
    
    private void HandleLeftTriggerCanceled(InputAction.CallbackContext context)
    {
        OnLeftTriggerCanceled?.Invoke();
    }
    
    private void HandleRightTriggerCanceled(InputAction.CallbackContext context)
    {
        OnRightTriggerCanceled?.Invoke();
    }
    
    private void HandleLeftShoulderCanceled(InputAction.CallbackContext context)
    {
        OnLeftShoulderCanceled?.Invoke();
    }
    
    private void HandleRightShoulderCanceled(InputAction.CallbackContext context)
    {
        OnRightShoulderCanceled?.Invoke();
    }
    
    private void HandleLeftStickPressCanceled(InputAction.CallbackContext context)
    {
        OnLeftStickPressCanceled?.Invoke();
    }
    
    private void HandleRightStickPressCanceled(InputAction.CallbackContext context)
    {
        OnRightStickPressCanceled?.Invoke();
    }
    
    private void HandlePadLeftCanceled(InputAction.CallbackContext context)
    {
        OnPadLeftCanceled?.Invoke();
    }
    
    private void HandlePadRightCanceled(InputAction.CallbackContext context)
    {
        OnPadRightCanceled?.Invoke();
    }
    
    private void HandlePadUpCanceled(InputAction.CallbackContext context)
    {
        OnPadUpCanceled?.Invoke();
    }
    
    private void HandlePadDownCanceled(InputAction.CallbackContext context)
    {
        OnPadDownCanceled?.Invoke();
    }
    
    private void HandleLeftStickLeftCanceled(InputAction.CallbackContext context)
    {
        OnLeftStickLeftCanceled?.Invoke();
    }
    
    private void HandleLeftStickRightCanceled(InputAction.CallbackContext context)
    {
        OnLeftStickRightCanceled?.Invoke();
    }
    
    private void HandleLeftStickUpCanceled(InputAction.CallbackContext context)
    {
        OnLeftStickUpCanceled?.Invoke();
    }
    
    private void HandleLeftStickDownCanceled(InputAction.CallbackContext context)
    {
        OnLeftStickDownCanceled?.Invoke();
    }
    
    private void HandleRightStickLeftCanceled(InputAction.CallbackContext context)
    {
        OnRightStickLeftCanceled?.Invoke();
    }
    
    private void HandleRightStickRightCanceled(InputAction.CallbackContext context)
    {
        OnRightStickRightCanceled?.Invoke();
    }
    
    private void HandleRightStickUpCanceled(InputAction.CallbackContext context)
    {
        OnRightStickUpCanceled?.Invoke();
    }
    
    private void HandleRightStickDownCanceled(InputAction.CallbackContext context)
    {
        OnRightStickDownCanceled?.Invoke();
    }
    
    private void HandleButtonStartCanceled(InputAction.CallbackContext context)
    {
        OnButtonStartCanceled?.Invoke();
    }
    
    private void HandleButtonSelectCanceled(InputAction.CallbackContext context)
    {
        OnButtonSelectCanceled?.Invoke();
    }
}
