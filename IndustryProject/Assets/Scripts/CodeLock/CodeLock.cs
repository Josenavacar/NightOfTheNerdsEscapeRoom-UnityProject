using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviourPunCallbacks
{
    [SerializeField] private CodeDisplay codeDisplay;
    [SerializeField] private LockedDoorTrigger lockedDoorTrigger;
    [SerializeField] private CodeLockHintManager codeLockHintManager;

    [SerializeField] private PhotonView PV;

    private string currentCode;
    private string attemptedCode;

    private int codeLength = 6;
    private int numberOfButtonsPressed = 0;
    private float countDown = 2;
    private float currentCountDown = 0;
    private bool falseAttempt = false;

    //private void Awake()
    //{
    //    PV = GetComponent<PhotonView>();
    //}

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GenerateCode();
            PV.RPC("SafeCode", RpcTarget.OthersBuffered, currentCode);
            SafeCode(currentCode);
        }
    }

    [PunRPC]
    private void SafeCode(string code)
    {
        currentCode = code;
        codeLockHintManager.HandleCode(currentCode);
        Debug.Log(currentCode);
    }

    private void GenerateCode()
    {
        for (int i = 0; i < codeLength; i++)
        {
            currentCode += Random.Range(0, 10).ToString();
        }
    }
 
    public void HandleButton(int value)
    {
        PV.RPC("RPCHandleLockButton", RpcTarget.Others, value);
        RPCHandleLockButton(value);
    }

    [PunRPC]
    private void RPCHandleLockButton(int value)
    {
        SoundObjectManager.instance.PlaySoundByAudioName(EnumAudioName.BUTTON_PRESS);
        numberOfButtonsPressed++;
        if (numberOfButtonsPressed <= codeLength)
        {
            attemptedCode += value.ToString();
            codeDisplay.SetText(attemptedCode);
        }

        if (numberOfButtonsPressed == codeLength)
        {
            CheckCode();
        }
    }

    private void CheckCode()
    {
        if (attemptedCode.Equals(currentCode))
        {
            attemptedCode = "CORRECT";
            codeDisplay.SetText(attemptedCode);
            lockedDoorTrigger.CodeSolved();
        }
        else
        {            
            attemptedCode = "FALSE";
            codeDisplay.SetText(attemptedCode);
            currentCountDown = countDown;
            falseAttempt = true;
        }
        
    }

    private void Update()
    {
        if (falseAttempt)
        {
            currentCountDown -= Time.deltaTime;

            if (currentCountDown <= 0)
            {
                ResetDisplay();
            }
        }
    }

    private void ResetDisplay()
    {
        attemptedCode = "";
        codeDisplay.SetText(attemptedCode);
        numberOfButtonsPressed = 0;
        falseAttempt = false;
    }
}
