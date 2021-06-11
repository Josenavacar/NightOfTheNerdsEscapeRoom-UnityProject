using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDStrip : MonoBehaviour
{
    public GameObject button_sphere;
    

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = button_sphere.GetComponent<MeshRenderer>().material.color;
    }
}
