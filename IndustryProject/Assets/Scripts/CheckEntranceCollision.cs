using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CheckEntranceCollision : MonoBehaviourPunCallbacks
{
    private int playerCount;

    [SerializeField] private int playersNeededToStart = 0;

    [SerializeField] private StartGame startGame;
    
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.CompareTag("Player"))
        {
            Debug.Log("Enter");
            playerCount++;
            CheckForStartTimer();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.transform.CompareTag("Player"))
        {
            Debug.Log("Exit");
            playerCount--;
            CheckForStartTimer();
        }
    }

    private void CheckForStartTimer() 
    {
        SoundObjectManager.instance.PlaySoundByAudioName(EnumAudioName.ENTER_PLATFORM);

        if(playerCount == playersNeededToStart)
        {
            SoundObjectManager.instance.PlaySoundByAudioName(EnumAudioName.EVERYONE_IN_PLATFORM);
            startGame.StartTimer();
        }
        else
        {
            startGame.StopTimer();
        }
    }

    public int PlayersNeededToStart { get => playersNeededToStart; private set => playersNeededToStart = value; }
}
