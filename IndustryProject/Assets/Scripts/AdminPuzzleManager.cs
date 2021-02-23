using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminPuzzleManager : MonoBehaviour
{
    [SerializeField] private string answer = "Admin";

    [SerializeField] private StairsAnimator stairAnimator;

    private string currentAnswer = "";

    private PhotonView PV;

    private void Start()
    {
        answer = answer.ToLower();
        AnswerScreen.instance.UpdateText(currentAnswer);
        PV = GetComponent<PhotonView>();
    }

    [PunRPC]
    public void AddToAnswerRPC(string letter)
    {
        currentAnswer += letter.ToLower();

        AnswerScreen.instance.UpdateText(currentAnswer);

        CheckAnswer();
    }

    public void AddToAnswer(string letter)
    {
        currentAnswer += letter.ToLower();

        AnswerScreen.instance.UpdateText(currentAnswer);

        CheckAnswer();

        PV.RPC("AddToAnswerRPC", RpcTarget.Others, letter);
    }

    private void CheckAnswer()
    {
        if (currentAnswer.Length >= answer.Length)
        {
            if (currentAnswer == answer)
            {
                stairAnimator.ShowStairs();
            }
            else
            {
                currentAnswer = "";
            }
        }
    }
}
