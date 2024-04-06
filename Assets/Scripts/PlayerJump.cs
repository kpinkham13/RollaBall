using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerJump : MonoBehaviour
{
    private CharacterController _characterController;

    private Vector3 playerVelocity;
    private bool playerGrounded;
    [SerializeField] private float jumpHeight = 5.0f;
    private bool jumpPressed = false;

    private float gravityValue = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        actualJump();
    }

    void actualJump()
    {
        playerGrounded = _characterController.isGrounded;

        if(playerGrounded)
        {
            playerVelocity.y = 0.0f;
        }

        if(jumpPressed && playerGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -1.0f * gravityValue);
            jumpPressed = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        _characterController.Move(playerVelocity * Time.deltaTime);
    }

    void OnJump()
    {
        if(_characterController.velocity.y == 0)
        {
            jumpPressed = true;
        }
    }
}
