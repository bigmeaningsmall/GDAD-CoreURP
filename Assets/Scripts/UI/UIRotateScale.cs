using UnityEngine;

public class UIRotateScale : MonoBehaviour
{
    public RectTransform uiElement;

    // Rotation speed
    public float rotationSpeed = -5;
    //scale speed
    public float scaleSpeed = 0.25f;

    // Flags to toggle rotation and scaling
    private bool isRotating = false;
    private bool isScaling = false;

    void Update()
    {
        // Check for key presses to toggle rotation and scaling
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isRotating = !isRotating;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isScaling = !isScaling;
        }

        // Rotate UI element if toggled
        if (isRotating)
        {
            uiElement.Rotate(0, 0, 50 * (Time.deltaTime * rotationSpeed));
        }

        // Scale UI element (pulsate effect) if toggled
        if (isScaling)
        {
            float scale = 1 + Mathf.Sin(Time.time * 2) * scaleSpeed;
            uiElement.localScale = new Vector3(scale, scale, 1);
        }
    }
}