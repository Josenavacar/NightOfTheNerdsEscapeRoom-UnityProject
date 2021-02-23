using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;

    public Camera PlayerCamera { get => playerCamera; private set => playerCamera = value; }
}
