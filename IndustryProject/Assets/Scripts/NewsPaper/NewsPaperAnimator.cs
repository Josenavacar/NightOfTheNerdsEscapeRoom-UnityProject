using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperAnimator : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void NewsPaperOpen()
    {
        animator.SetTrigger("Open");
    }
}
