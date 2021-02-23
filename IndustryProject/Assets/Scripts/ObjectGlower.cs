using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGlower : MonoBehaviour
{ 
    [SerializeField] private float glowIntensity;

    [SerializeField] private Renderer renderer;

    private Color lastEmission;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lastEmission = renderer.material.GetColor("_EmissionColor");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            renderer.material.SetColor("_EmissionColor", lastEmission * glowIntensity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            renderer.material.SetColor("_EmissionColor", lastEmission);
        }
    }
}
