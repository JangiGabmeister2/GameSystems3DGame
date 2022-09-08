using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Game Systems/Player/Movement")]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(MenuHandler))]

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Header("Character")]

    public Vector3 moveDir;
    private CharacterController _charC;

    [Header("Character Speeds")]

    public float speed = 50f;
    public float jumpSpeed = 50f, gravity = 20f, crouch = 2.5f, walk = 50f, run = 10f;

    #endregion
    private MenuHandler _menu;

    void Start()
    {
        _charC = GetComponent<CharacterController>();
    }

    void Update()
    {
        //if in game state, movement is normal
        if (GameManager.GameManagerInstance.gameState == GameStates.GameState)
        {
            #region Movement
            if (_charC.isGrounded)
            {
                moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDir = transform.TransformDirection(moveDir);
                moveDir *= speed;

                if (Input.GetButton("Jump"))
                {
                    moveDir.y = jumpSpeed;
                }
            }

            moveDir.y -= gravity * Time.deltaTime;
            _charC.Move(moveDir * Time.deltaTime);
            #endregion
        }

        if (Input.GetButton("Escape"))
        {
            GameManager.GameManagerInstance.gameState = GameStates.MenuState;
            _menu.ChangeScene(1);
        }
    }
}
