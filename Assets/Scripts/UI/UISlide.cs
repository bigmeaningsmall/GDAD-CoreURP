using UnityEngine;
using System.Collections;

public class UISlide : MonoBehaviour
{
    public RectTransform panel; // Assign in Inspector
    public Vector2 hiddenPosition = new Vector2(-500, 0);
    public Vector2 visiblePosition = new Vector2(0, 0);
    public float duration = 0.5f;

    //press  the P button to toggle the panel
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (panel.anchoredPosition == hiddenPosition)
            {
                ShowPanel();
            }
            else
            {
                HidePanel();
            }
        }
    }
    
    
    public void ShowPanel()
    {
        StartCoroutine(MoveUI(panel, visiblePosition, duration));
    }

    public void HidePanel()
    {
        StartCoroutine(MoveUI(panel, hiddenPosition, duration));
    }

    IEnumerator MoveUI(RectTransform rectTransform, Vector2 target, float time)
    {
        Vector2 start = rectTransform.anchoredPosition;
        float elapsed = 0f;

        while (elapsed < time)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(start, target, elapsed / time);
            elapsed += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = target;
    }
}
