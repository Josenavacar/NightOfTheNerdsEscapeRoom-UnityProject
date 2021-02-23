using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmountToStartSetup : MonoBehaviour
{
    [SerializeField] private PlayerCounter playerCounter;
    private MeshFilter meshToChange;

    private void Start()
    {
        meshToChange = GetComponent<MeshFilter>();
        meshToChange.sharedMesh = playerCounter.NumberMeshes[playerCounter.NumberOfPlayersToStart].sharedMesh;
    }
}
