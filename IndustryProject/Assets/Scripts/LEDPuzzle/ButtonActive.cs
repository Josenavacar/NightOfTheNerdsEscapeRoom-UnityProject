using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActive : MonoBehaviour
{
    public bool activated = false;
    public bool finished = false;
    private float timer = 10;
    public GameObject sphereColour;

    // Start is called before the first frame update
    void Start()
    {
        sphereColour.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if(finished)
        {
            sphereColour.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if(activated)
        {
            timer -= Time.deltaTime;
            sphereColour.GetComponent<MeshRenderer>().material.color = Color.green;
            if (timer <= 0)
            {
                activated = false;
                sphereColour.GetComponent<MeshRenderer>().material.color = Color.red;
                timer = 10;

            }
        }
    }
}
