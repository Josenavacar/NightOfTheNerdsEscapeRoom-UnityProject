using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActive : MonoBehaviour
{
    public bool activated = false;
    private float timer = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activated)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                activated = false;
                timer = 10;
            }
        }
    }
}
