using UnityEngine;
using UnityEngine.InputSystem;

public class InputMessageExample : MonoBehaviour
{
    public Vector2 leftStickInput;
    
    private void OnLeftStick(InputValue value)
    {
        leftStickInput = value.Get<Vector2>();
    }

    private void OnButtonSouth()
    {
        print("Button South was pressed :  SEND MESSAGE");
    }

}
