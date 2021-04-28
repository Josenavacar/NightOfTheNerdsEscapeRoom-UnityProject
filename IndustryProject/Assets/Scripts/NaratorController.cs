using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NaratorController : MonoBehaviour
{
    [SerializeField]
    private string[] dialogue;

    [SerializeField]
    private TMP_Text dialogueBox;
    [SerializeField]
    private TMP_Text dialogueCounterText;
    private int dialogueCounter = 0;
    public Image backgroundImage;

    [SerializeField]
    private float interval = 8f;

    private IEnumerator coroutine;
    
    private Animator animator;
 

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartCoroutine()
    {
        coroutine = Wait(interval);
        backgroundImage.gameObject.SetActive(true);
        StartCoroutine(coroutine);
    }

    public void Stop()
    {
        StopAllCoroutines();
        StopTalking();
    }

    private IEnumerator Wait(float waitTime)
    {
        animator.SetTrigger("TurnOn");

        for (int i = 0; i < dialogue.Length; i++)
        {
            if(Random.Range(0, 2) >= 1) {
                animator.SetBool("Talking", true);
            }
            else {
                animator.SetBool("Talking", false);
            }
            dialogueBox.text = dialogue[i];
            dialogueCounter++;
            dialogueCounterText.text = dialogueCounter + "/" + dialogue.Length;

            yield return new WaitForSeconds(waitTime);

            if (i >= dialogue.Length - 1) {
                i = -1;
                dialogueCounter = 0;
            }
        }
    }

    private void StopTalking()
    {
        dialogueBox.text = "";
        dialogueCounterText.text = "";
        dialogueCounter = 0;
        backgroundImage.gameObject.SetActive(false);
        animator.SetBool("Talking", false);
        animator.SetTrigger("TurnOff");
    }
}
