using UnityEngine;

public class UIPositioning : MonoBehaviour
{
    public RectTransform uiElement; // Assign in Inspector

    void Start()
    {
        // Center the UI element
        uiElement.anchoredPosition = Vector2.zero;
    }
}
