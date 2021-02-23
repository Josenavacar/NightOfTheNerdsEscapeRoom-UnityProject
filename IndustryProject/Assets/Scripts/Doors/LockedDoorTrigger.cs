using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorTrigger : DoorTrigger
{
    private bool codeSolved = false;

    private void Update()
    {
        if (getPlayerInZone())
        {
            if (!getDoorOpen() && codeSolved)
                OpenDoor();
        }
        else
        {
            if (getDoorOpen())
                CloseDoor();
        }
    }

    public void CodeSolved()
    {
        codeSolved = true;               
    }
}
