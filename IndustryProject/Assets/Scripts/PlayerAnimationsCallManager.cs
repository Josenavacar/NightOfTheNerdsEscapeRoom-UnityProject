using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationsCallManager : MonoBehaviour
{
    private Animator animator;

    private bool isWalking = false;
    private bool isJumping = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetWalkingBool(bool newWalkingBool)
    {
        if (isWalking != newWalkingBool)
        {
            isWalking = newWalkingBool;
            animator.SetBool("Walking", newWalkingBool);
        }
    }

    public void SetJumpingTrigger()
    {
        animator.SetTrigger("Jumping");
    }

    public void SetInteractionTrigger()
    {
        animator.SetTrigger("Interact");
    }
}
