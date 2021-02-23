using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviourPunCallbacks
{
    [SerializeField] private List<MeshFilter> meshesToChange = new List<MeshFilter>();

    private EnumPlayerClasses currentPlayerClass = EnumPlayerClasses.DEFAULT;

    private PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    
    public void ChangePlayerClass(EnumPlayerClasses enumPlayerClass)
    {
        if (ClassManager.instance.CanSelectClass(enumPlayerClass))
        {
            DeSelectClass(currentPlayerClass);

            SelectClass(enumPlayerClass);

            PlayerPrefs.SetInt("Class", (int)currentPlayerClass);

            PV.RPC("ChangePlayerClassRPC", RpcTarget.Others, (int)enumPlayerClass, (int)currentPlayerClass);
        }
    }

    [PunRPC]
    public void ChangePlayerClassRPC(int playerClass, int toRemove)
    {
        DeSelectClass((EnumPlayerClasses)toRemove);

        SelectClass((EnumPlayerClasses)playerClass);
    }

    private void UpdatePlayerClassGraphic(List<MeshFilter> lstMeshes)
    {
        for (int i = 0; i < lstMeshes.Count; i++)
        {
            meshesToChange[i].sharedMesh = lstMeshes[i].sharedMesh;
        }
    }

    private void DeSelectClass(EnumPlayerClasses toRemove)
    {
        if (currentPlayerClass != EnumPlayerClasses.DEFAULT)
        {
            ClassManager.instance.DeSelectClass(currentPlayerClass);
        }
    }

    private void SelectClass(EnumPlayerClasses toSelect)
    {
        ClassManager.instance.SelectClass(toSelect);

        currentPlayerClass = toSelect;

        UpdatePlayerClassGraphic(ClassManager.instance.getMeshes(toSelect));
    }

    private void OnApplicationQuit()
    {
        //Reset player class to default if we quit the app
        PlayerPrefs.SetInt("Class", (int)EnumPlayerClasses.DEFAULT);
    }

    public EnumPlayerClasses CurrentPlayerClass { get => currentPlayerClass; }
}
