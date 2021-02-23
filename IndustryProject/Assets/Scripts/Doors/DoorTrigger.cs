using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private bool isFence = false;
    private PhotonView photonView;
    private DoorAnimator doorAnimator;   
    private bool doorIsOpen;   
    private bool playerInZone;
        
    private void Start()
    {        
        doorIsOpen = false;
        playerInZone = false;
        doorAnimator = GetComponent<DoorAnimator>();        
    }
   
    private void Update()
    {
        if (playerInZone)
        {
            if(!doorIsOpen)
            OpenDoor();
        }
        else
        {
            if(doorIsOpen)
            CloseDoor();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        SetupPhotonView(other);     
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInZone = false;         
        }
    }
    public void SetupPhotonView(Collider other)
    {
        if (photonView == null)
        {
            PhotonView tempPhotonView;
            tempPhotonView = other.gameObject.GetComponent<PhotonView>();
            if (tempPhotonView.IsMine)
            {
                photonView = tempPhotonView;
            }
        }
    }
    public void OpenDoor()
    {        
            if (photonView != null && photonView.IsMine)
            {
                PlayOpenSound();
                doorIsOpen = true;
                doorAnimator.DoorOpen();
            }             
    }

    public void PlayOpenSound(){
        if(isFence == true){
            SoundObjectManager.instance.PlaySoundByAudioName(EnumAudioName.FENCE);
        }
        else{
            SoundObjectManager.instance.PlaySoundByAudioName(EnumAudioName.DOORS);
        }
    }
    public void CloseDoor()
    {
        if (photonView != null && photonView.IsMine)
        {           
            if (!playerInZone)
            {
                doorIsOpen = false;
                doorAnimator.DoorClose();
            }
        }
    }

    public bool getPlayerInZone()
    {
        return playerInZone;
    }

    public bool getDoorOpen()
    {
        return doorIsOpen;
    }

}
