using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Inputs _inputs;
    [SerializeField] private GameState gameState = GameState.GamePlay; 
    private enum GameState
    {
        GamePlay,
        UI
    }
    private void Awake()
    {
        _inputs = new Inputs();
    }

    private void OnEnable()
    {
        _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Disable();
    }

    private void Start()
    {
        _inputs.GamePlay.Move.performed += MoveOnPerformed;
        _inputs.GamePlay.Interact.started += InteractOnStarted;
        _inputs.GamePlay.Cancel.started += CancelOnStarted;
        
    }

    private void CancelOnStarted(InputAction.CallbackContext obj)
    {
        if (gameState == GameState.UI)
        {
            //send info to UI controller
        }
    }

    private void InteractOnStarted(InputAction.CallbackContext obj)
    {
        if (gameState == GameState.GamePlay)
        {
            //check if has an Iinteractable infront and send info to Iinteractable object
        }

        if (gameState == GameState.UI)
        {
            //send info to  UI controller
        }
    }

    private void MoveOnPerformed(InputAction.CallbackContext obj)
    {
        var dir = obj.ReadValue<Vector2>();
        if (gameState == GameState.GamePlay)
        {
            //send info to player controller
        }
        else
        {
            //send info to UI controller
        }
    }
}
