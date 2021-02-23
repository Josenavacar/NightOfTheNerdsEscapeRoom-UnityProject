using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersInRoomManager : MonoBehaviourPunCallbacks
{
    #region SingleTon
    public static PlayersInRoomManager instance;
    private void Awake()
    {
        if(instance == null || instance != this)
        {
            instance = this;
            
        }
    }
    #endregion

 
    private static int personCounter = 0;
    private List<Transform> playerTransforms = new List<Transform>();

    public List<Transform> PlayerTransforms { get => playerTransforms; private set => playerTransforms = value; }
       
    public void AddPlayerToRoom(Transform playerTransform){        
        playerTransforms.Add(playerTransform);        
    }   
      

    public Transform getPlayerByIndex(int playerIndex)
    {
        return PlayerTransforms[playerIndex];
    }
}
