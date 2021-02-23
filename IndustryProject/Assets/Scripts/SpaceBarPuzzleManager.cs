using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceBarPuzzleManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private int playersNeeded = 4;
    [SerializeField] private int sceneToLoad = 4;
    private int currentPlayersInSpacebarZone = 0;

    private void CheckForCompletion()
    {
        if (currentPlayersInSpacebarZone == playersNeeded)
        {
            PhotonNetwork.LoadLevel(sceneToLoad);
        }
    }

    public void SomeoneEntered()
    {
        currentPlayersInSpacebarZone++;
        CheckForCompletion();
    }

    public void SomeoneLeft()
    {
        currentPlayersInSpacebarZone--;
    }
}
