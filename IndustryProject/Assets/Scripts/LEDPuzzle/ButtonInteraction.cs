using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    List<GameObject> buttons;

    // Start is called before the first frame update
    void Start()
    {
        buttons = new List<GameObject>(GameObject.FindGameObjectsWithTag("LEDButton"));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && buttons.Count > 0)
        {
            foreach(GameObject button in buttons)
            {
                if(Vector3.Distance(this.gameObject.transform.position, button.transform.position) < 3)
                {
                    button.GetComponent<ButtonActive>().activated = true;
                }
            }
        }
    }
}
