using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviourPunCallbacks
{
    [Header("Player speeds")]
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;

    [Header("Gravity calculation")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    [Header("Transform")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private CharacterController controller;
    [SerializeField] private PlayerAnimationsCallManager animator;

    private Vector3 velocity;
    private bool isGrounded;

    private PhotonView PV;

    private float time = 0.0f;
    private float interpolationPeriod = .4f;

    private void Start()
    {
        PV = GetComponentInParent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            Gravity();
            Move();
            Jump();
        }
    }

    private void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    public void PlayFootstepSound(){
        time += Time.deltaTime;
        if(time >= interpolationPeriod){
            time -= interpolationPeriod;
            SoundObjectManager.instance.PlaySoundByAudioName(EnumAudioName.FOOTSTEPS);
        }
    }

    private void Move()
    {
        float x = InputReader.instance.HorizontalAxis;
        float z = InputReader.instance.VerticalAxis;

        SetMoveAnimation(x, z);

        Vector3 move = playerTransform.right * x + playerTransform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    private void SetMoveAnimation(float x, float z)
    {
        if (x == 0 && z == 0)
        {
            animator.SetWalkingBool(false);
        }
        else
        {
            PlayFootstepSound();
            animator.SetWalkingBool(true);
        }
    }

    private void Jump()
    {
        if (InputReader.instance.Jump && isGrounded)
        {
            animator.SetJumpingTrigger();
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public bool IsGrounded { get => isGrounded; private set => isGrounded = value; }
}
