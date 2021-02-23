using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EndScreenController : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel;

    private bool isScrolling = false;

    public void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }

    public void Update()
    {
        if (scrollRect.verticalNormalizedPosition >= 0.05f && !isScrolling)
        {
            Scroll(0.0004f);
        }
    }

    public void Scroll(float add)
    {
        Canvas.ForceUpdateCanvases();

        scrollRect.verticalNormalizedPosition = scrollRect.verticalNormalizedPosition - add;
    }

    public void SetScrolling()
    {
        isScrolling = true;
    }

    public void SetNotScrolling()
    {
        isScrolling = false;
    }

    public void RestartClick()
    {
        Debug.Log("You have clicked the button!");
    }

    public void QuitClick()
    {
        Debug.Log("You have clicked the button!");
    }
}
