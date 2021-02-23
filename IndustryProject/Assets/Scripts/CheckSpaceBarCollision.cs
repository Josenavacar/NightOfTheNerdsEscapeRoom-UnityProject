using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpaceBarCollision : MonoBehaviour
{
    [SerializeField] private EnumPlayerClasses ClassForThisTrigger = EnumPlayerClasses.DEFAULT;

    [Header("Outline properties")]
    [SerializeField] private MeshRenderer outline;
    [SerializeField] private Material redOutline;
    [SerializeField] private Material greenOutline;

    private bool isRed = true;

    private PlayerClass playerClass;

    private SpaceBarPuzzleManager puzzleManager;

    private void Start()
    {
        puzzleManager = GetComponentInParent<SpaceBarPuzzleManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.CompareTag("Player") && playerClass == null)
        {
            playerClass = collider.GetComponent<PlayerClass>();
            EnumPlayerClasses currentPlayerClass = playerClass.CurrentPlayerClass;

            if (currentPlayerClass == ClassForThisTrigger)
            {
                //We have the correct class in the trigger zone
                ChangeColor();
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.CompareTag("Player") && playerClass != null)
        {
            EnumPlayerClasses currentPlayerClass = playerClass.CurrentPlayerClass;

            if (currentPlayerClass == ClassForThisTrigger)
            {
                //We have the correct class in the trigger zone
                ChangeColor();
            }

            //ResetPlayer
            playerClass = null;
        }
    }

    private void ChangeColor()
    {
        if (isRed)
        {
            //is red before calling this
            isRed = false;
            puzzleManager.SomeoneEntered();
            outline.sharedMaterial = greenOutline;
            SoundObjectManager.instance.PlaySoundByAudioName(EnumAudioName.EVERYONE_IN_PLATFORM);
        }
        else
        {
            //Not red before calling this we are gonna leave now
            isRed = true;
            puzzleManager.SomeoneLeft();
            outline.sharedMaterial = redOutline;
        }
    }
}
