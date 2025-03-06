using UnityEngine;

public class UIMove : MonoBehaviour
{
    public RectTransform button; // Assign in Inspector
    public Vector2 targetPosition = new Vector2(200, 100);
    public float speed = 5f;

    void Update()
    {
        button.anchoredPosition = Vector2.Lerp(button.anchoredPosition, targetPosition, Time.deltaTime * speed);
    }
}
