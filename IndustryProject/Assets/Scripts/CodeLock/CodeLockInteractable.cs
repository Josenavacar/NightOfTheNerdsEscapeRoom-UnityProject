using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLockInteractable : Interactable
{
    CodeLock codeLock;
    [SerializeField] private int number;

    private void Start()
    {
        codeLock = GetComponentInParent<CodeLock>();
    }
        
    public override void HandleAction(Transform transform)
    {
        codeLock.HandleButton(number);
    }
}
