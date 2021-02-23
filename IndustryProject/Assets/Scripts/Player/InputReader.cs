using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    #region singleton

    public static InputReader instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    private float horizontalAxis = 0;
    private float verticalAxis = 0;

    private float mouseX;
    private float mouseY;

    private float mouseScrollWheel;

    private Vector3 mousePos;

    private bool jump = false;
    private bool interact = false;

    private bool onPhone = false;
    private bool nextPage = false;
    private bool previousPage = false;


    private PhotonView PV;

    // Update is called once per frame
    void Update()
    {
        ReadMovement();
        ReadMouseInput();
        ReadButtons();
    }

    private void ReadButtons()
    {
        interact = Input.GetKeyDown(KeyCode.E);     
        onPhone = Input.GetKeyDown(KeyCode.Q);
        nextPage = Input.GetKeyDown(KeyCode.N);
        previousPage = Input.GetKeyDown(KeyCode.M);
    }

    private void ReadMovement()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        jump = Input.GetButtonDown("Jump");
    }

    private void ReadMouseInput()
    {
        mousePos = Input.mousePosition;
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
    }

    public bool Jump { get => jump; }
    public float HorizontalAxis { get => horizontalAxis; }
    public float VerticalAxis { get => verticalAxis; }
    public float MouseX { get => mouseX; }
    public float MouseY { get => mouseY; }
    public bool Interact { get => interact; }
    public Vector3 MousePos { get => mousePos; }
    public float MouseScrollWheel { get => mouseScrollWheel; }
    public bool OnPhone { get => onPhone; }
    public bool NextPage { get => nextPage; }
    public bool PreviousPage { get => previousPage; }
}
