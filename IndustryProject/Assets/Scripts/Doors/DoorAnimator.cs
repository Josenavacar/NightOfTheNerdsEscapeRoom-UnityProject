using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DoorOpen()
    {
        animator.SetTrigger("Open");
    }

    public void DoorClose()
    {
        animator.SetTrigger("Close");
    }
}
