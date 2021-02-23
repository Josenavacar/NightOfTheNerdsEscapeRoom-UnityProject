using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceLockInteractable : Interactable
{
    FenceLock fenceLock;

    // Start is called before the first frame update
    private void Start()
    {
        fenceLock = GetComponentInParent<FenceLock>();
    }

    public override void HandleAction(Transform transform)
    {
        fenceLock.HandleAction(transform);
    }
}
