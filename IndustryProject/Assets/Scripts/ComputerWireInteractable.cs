using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerWireInteractable : Interactable
{
    ComputerScreen computerScreen;
    
    void Start()
    {
        computerScreen = GetComponentInParent<ComputerScreen>();
    }

    public override void HandleAction(Transform transform)
    {
        computerScreen.PickedUpWire();
    }
}
