using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassUnlockDoor : DoorTrigger
{
    private List<PlayerClass> playerClassesInRoom = new List<PlayerClass>();

    private bool doorOpen = false;

    private new void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        PlayerClass playerClass = other.GetComponent<PlayerClass>();
        playerClassesInRoom.Add(playerClass);
    }

    private new void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);

        bool doorCanOpen = true;

        foreach (PlayerClass playerClass in playerClassesInRoom)
        {
            if (playerClass.CurrentPlayerClass == EnumPlayerClasses.DEFAULT)
            {
                doorCanOpen = false;
            }
        }

        doorOpen = doorCanOpen;
    }

    private void Update()
    {
        if (getPlayerInZone())
        {
            if (!getDoorOpen() && doorOpen)
                OpenDoor();
        }
        else
        {
            if (getDoorOpen())
                CloseDoor();
        }
    }
}
