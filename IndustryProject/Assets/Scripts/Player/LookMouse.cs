using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouse : MonoBehaviourPunCallbacks
{
    [SerializeField] private float mouseSensitivity = 150f;

    [SerializeField] private Transform playerBody;

    private float xRotation = 0f;

    private PhotonView PV;
    
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponentInParent<PhotonView>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            float mouseX = InputReader.instance.MouseX * mouseSensitivity * Time.deltaTime;
            float mouseY = InputReader.instance.MouseY * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
