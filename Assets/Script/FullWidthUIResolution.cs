using UnityEngine;

public class FullWidthUIResolution : MonoBehaviour
{
    RectTransform rect;
    private void Awake()
    {
        rect = transform.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(Screen.width, rect.sizeDelta.y);
    }
}