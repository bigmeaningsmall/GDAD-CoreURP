using UnityEngine;

public class LegacyInputExample : MonoBehaviour
{
    public Vector2 leftStickInput;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            print("Alpha1 key was pressed");
        }
        
        leftStickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        if (leftStickInput != Vector2.zero){
            print("Left Stick Input: " + leftStickInput);
        }
    }
}
