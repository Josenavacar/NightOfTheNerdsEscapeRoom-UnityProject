using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminButtonInteractable : Interactable
{
    [SerializeField] private string letter;
   
    [SerializeField] TMPro.TMP_Text textField;

    private AdminPuzzleManager puzzleManager;

    private void Start()
    {
        puzzleManager = GetComponentInParent<AdminPuzzleManager>();

        textField.text = letter;
    }

    public override void HandleAction(Transform transform)
    {
        base.HandleAction(transform);
        SoundObjectManager.instance.PlaySoundByAudioName(EnumAudioName.BUTTON_PRESS);
        puzzleManager.AddToAnswer(letter);
    }
}
