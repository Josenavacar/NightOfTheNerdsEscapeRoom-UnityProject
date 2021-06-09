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
        //canvasInput = FindObjectOfType<TMPro.TMP_InputField>();
        //Debug.Log($"{transform.parent.parent.GetComponentInChildren<TMPro.TMP_InputField>().name}");
        canvasInput = transform.parent.parent.GetComponentInChildren<TMPro.TMP_InputField>();
        shownText = GetComponent<TMPro.TextMeshProUGUI>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        inputPlayer = canvasInput.text;
        shownText.SetText(inputPlayer);
    }
}
