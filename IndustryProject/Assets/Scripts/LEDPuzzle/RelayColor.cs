using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayColor : MonoBehaviour
{
    public bool greenTime;

    // Update is called once per frame
    void Update()
    {
        if(greenTime)
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
