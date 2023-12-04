using Player;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Inputs _inputs;
    public GameState gameState = GameState.GamePlay;
    private PlayerController _player;
    private HUDController _hud;
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
        _hud = Bootstrap.Instance.hudC;
        _player = Bootstrap.Instance.pC;
        _inputs.GamePlay.Move.performed += Move;
        _inputs.GamePlay.Interact.started += Interact;
        _inputs.GamePlay.Cancel.started += Cancel;
        _inputs.GamePlay.Move.canceled += Move;
    }

    private void Cancel(InputAction.CallbackContext obj)
    {
        if (gameState == GameState.UI)
        {
            _hud.CloseHud();
        }
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        if (gameState == GameState.GamePlay)
        {
            _hud.OpenHud();
        }
        else
        {
            _hud.ClickBtn();
        }
        
    }

    private void Move(InputAction.CallbackContext obj)
    {
        var dir = obj.ReadValue<Vector2>();
        if (gameState == GameState.GamePlay)
        {
            _player.SetDirection(dir);
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
