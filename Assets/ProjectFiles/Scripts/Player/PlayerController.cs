using System.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace prasetion
{

    public class PlayerController : MonoBehaviour, prasetion.PlayerInput.IPlayerActions
    {

        PlayerInput controls;

        PlayerAnimationController playerAnimationController;
        PlayerMovement playerMovement;

        [Header("Input Settings")]
        public PlayerInput playerInput;
        public float movementSmoothingSpeed = 1f;
        private Vector3 rawInputMovement;
        private Vector3 smoothInputMovement;

        void Start()
        {
            playerAnimationController = GetComponent<PlayerAnimationController>();
            playerMovement = GetComponent<PlayerMovement>();
        }

        public void OnEnable()
        {
            if (controls == null)
            {
                controls = new PlayerInput();
                // Tell the "gameplay" action map that we want to get told about
                // when actions get triggered.
                controls.Player.SetCallbacks(this);
            }
            controls.Player.Enable();
        }

        public void OnDisable()
        {
            controls.Player.Disable();
        }

        //Update Loop - Used for calculating frame-based data
        void Update()
        {
            CalculateMovementInputSmoothing();
            UpdatePlayerMovement();
            UpdatePlayerAnimationMovement();
        }

        public void OnMove(InputAction.CallbackContext value)
        {
            // throw new NotImplementedException();
            Vector2 inputMovement = value.ReadValue<Vector2>();
            rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
        }

        public void OnAttack(InputAction.CallbackContext value)
        {

            if (value.started)
            {
                Debug.Log("attack");
                playerAnimationController.OnAttack();
            }
        }

        void CalculateMovementInputSmoothing()
        {
            smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);
        }

        void UpdatePlayerMovement()
        {
            playerMovement.UpdateMovementData(smoothInputMovement);
        }

        void UpdatePlayerAnimationMovement()
        {
            playerAnimationController.OnMove(smoothInputMovement.magnitude);
        }
    }

}