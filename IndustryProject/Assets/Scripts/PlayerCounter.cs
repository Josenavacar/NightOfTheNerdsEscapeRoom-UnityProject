using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CheckEntranceCollision))]
public class PlayerCounter : MonoBehaviour
{
    #region singleton

    public static PlayerCounter instance;
    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }

        numberOfPlayersToStart = GetComponent<CheckEntranceCollision>().PlayersNeededToStart;
    }
    #endregion

    [SerializeField] private List<MeshFilter> numberMeshes;
    [SerializeField] private GameObject leftNumber;

    [Header("Counter properties")]
    [SerializeField] private GameObject counter;
    [SerializeField] private Material counterRed;
    [SerializeField] private Material counterGreen;

    [Header("Outline properties")]
    [SerializeField] private GameObject outline;
    [SerializeField] private Material redOutline;
    [SerializeField] private Material greenOutline;

    private int numberOfPlayersToStart = 4;

    private int playerCount = 0;
    
    private void UpdateColor() 
    {
        MeshFilter mesh = numberMeshes[playerCount];
        leftNumber.GetComponent<MeshFilter>().sharedMesh = mesh.sharedMesh;

        if (playerCount == numberOfPlayersToStart)
        {
            LoopMeshRenderer(counterGreen);

            outline.GetComponent<MeshRenderer>().sharedMaterial = greenOutline;
        }
        else
        {
            LoopMeshRenderer(counterRed);

            outline.GetComponent<MeshRenderer>().sharedMaterial = redOutline;
        }
    }

    private void LoopMeshRenderer(Material counterColor)
    {
        foreach (var item in counter.GetComponentsInChildren<MeshRenderer>())
        {
            item.sharedMaterial = counterColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCount++;

            UpdateColor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCount--;
            
            UpdateColor();
        }
    }

    public List<MeshFilter> NumberMeshes { get => numberMeshes; private set => numberMeshes = value; }
    public int NumberOfPlayersToStart { get => numberOfPlayersToStart; private set => numberOfPlayersToStart = value; }
}
