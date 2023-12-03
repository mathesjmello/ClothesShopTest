using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Inputs _inputs;
    public GameState gameState = GameState.GamePlay;

    public enum GameState
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
        
        _inputs.GamePlay.Move.performed += Move;
        _inputs.GamePlay.Interact.started += Interact;
        _inputs.GamePlay.Cancel.started += Cancel;
        _inputs.GamePlay.Move.canceled += Move;
    }

    private void Cancel(InputAction.CallbackContext obj)
    {
        if (gameState == GameState.UI)
        {
            Bootstrap.Instance.hudC.CloseHud();
        }
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        if (gameState == GameState.GamePlay)
        {
            Bootstrap.Instance.hudC.OpenHud();
        }
        else
        {
            Bootstrap.Instance.hudC.ClickBtn();
        }
        
    }

    private void Move(InputAction.CallbackContext obj)
    {
        var dir = obj.ReadValue<Vector2>();
        if (gameState == GameState.GamePlay)
        {
            //send info to player controller
            Bootstrap.Instance.pC.SetDirection(dir);
        }
        else
        {
            //send info to UI controller
        }
    }

    public void SwitchActionMap()
    {
        if (gameState == GameState.GamePlay)
        {
            gameState = GameState.UI;
        }else
        {
            gameState = GameState.GamePlay;
        }
    }
}
