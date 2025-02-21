using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class InputUnityEventExample : MonoBehaviour
{
    public Vector2 leftStickInput;
    
    //unity event from input system
    public void OnLeftStick(InputAction.CallbackContext context)
    {
        leftStickInput = context.ReadValue<Vector2>();
    }

    public void OnButtonSouth()
    {
        print("Button South was pressed : UNITY EVENT");
    }
}
