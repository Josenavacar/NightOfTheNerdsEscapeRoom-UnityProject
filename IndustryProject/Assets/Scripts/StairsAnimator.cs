using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsAnimator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowStairs()
    {
        animator.SetBool("ShowStairs", true);
    }
}
