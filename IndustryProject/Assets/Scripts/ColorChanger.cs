using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private MeshRenderer objectToChange;

    [SerializeField] private Material available;
    [SerializeField] private Material unavailable;

    private void Start()
    {
        objectToChange = GetComponent<MeshRenderer>();
    }

    public void ChangeColor(bool isSelected)
    {
        if (isSelected)
        {
            objectToChange.sharedMaterial = unavailable;
        }
        else
        {
            objectToChange.sharedMaterial = available;
        }
    }
}
