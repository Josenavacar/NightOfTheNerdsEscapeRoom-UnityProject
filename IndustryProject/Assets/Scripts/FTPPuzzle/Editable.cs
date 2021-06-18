using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Editable : MonoBehaviour
{
    //MUST HAVE RIGIDBODY2D AND COLLIDER2D 
    public TMPro.TMP_InputField canvasInput;
    public TMPro.TextMeshProUGUI shownText;
    public Button button;
    public GameObject thisFunction;

    // Start is called before the first frame update
    void Start()
    {
        //canvasInput = FindObjectOfType<TMPro.TMP_InputField>();
        //Debug.Log($"{transform.parent.parent.GetComponentInChildren<TMPro.TMP_InputField>().name}");
        canvasInput = transform.parent.GetComponentInChildren<TMPro.TMP_InputField>();
        button = GetComponent<Button>();
    }
    public void EditNumber()
    {
        shownText.text = canvasInput.text;
    }
    private void Update()
    {
        if (thisFunction.GetComponentInChildren<outputFunction>().puzzleCompleted)
        {
           button.interactable = false;
           
        }
        else
        {
            button.interactable = true;
        }
    }


}
