using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SetupManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform spawnPoint;

    private PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    private void Start()
    {
        Debug.Log("Creating player");
        GameObject Player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","FPPlayer"), spawnPoint.position, spawnPoint.rotation);
      
        PV = Player.GetComponent<PhotonView>();

        if (PV.IsMine)
        {
            Camera cam = Player.GetComponentInChildren<PlayerInfo>().PlayerCamera;
            cam.gameObject.SetActive(true);
            SetupClass(Player);
        }

        GameObject go = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","PlayerStats"), Vector3.zero, Quaternion.identity);
        PlayerStats stats = go.GetComponent<PlayerStats>();
    }

    private void SetupClass(GameObject player)
    {
        if ((EnumPlayerClasses)PlayerPrefs.GetInt("Class") != EnumPlayerClasses.DEFAULT)
        {
            Debug.Log("No default class");
            player.GetComponent<PlayerClass>().ChangePlayerClass((EnumPlayerClasses)PlayerPrefs.GetInt("Class"));
        }
    }
}
