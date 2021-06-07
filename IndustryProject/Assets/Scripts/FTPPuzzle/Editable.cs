using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Editable : MonoBehaviour, IPointerClickHandler
{
    //MUST HAVE RIGIDBODY2D AND COLLIDER2D 
    public TMPro.TMP_InputField canvasInput;
    public TMPro.TextMeshProUGUI shownText;

    public string inputPlayer = "0";

    // Start is called before the first frame update
    void Start()
    {
        canvasInput = FindObjectOfType<TMPro.TMP_InputField>();
        shownText = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        inputPlayer = canvasInput.text;
        shownText.SetText(inputPlayer);
    }
}
