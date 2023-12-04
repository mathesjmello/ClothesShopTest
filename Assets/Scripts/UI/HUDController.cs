using System;
using Player;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class HUDController : MonoBehaviour
    {
        private bool _isOpened;
        private int _collect;
        private PlayerController _player;
        private InputManager _input;
        public bool _secondTab;
        public bool canOpenHud;
        private CanvasGroup _hudToOpen;
        public CanvasGroup _previousCG;
        public BtnSelector _selector;
        public BtnSelector _previousSelector;

        private void Start()
        {
            _player = Bootstrap.Instance.pC;
            _input = Bootstrap.Instance.inputM;
        }

        public void OnTriggerCheck(CanvasGroup hud, BtnSelector btnSelector, int collect)
        {
            if (collect!=0)
            {
                _collect = collect;
            }
            canOpenHud = true;
            _hudToOpen = hud;
            _selector = btnSelector;
            
        }

        public void ExitTriggerCheck()
        {
            canOpenHud = false;
            _collect = 0;
        }

        public void OpenHud()
        {
            switch (_collect)
            {
                case 0:
                    break;
                case 1:
                    _player.eggs++;
                    Debug.Log("egg added");
                    //add egg
                return;
                case 2:
                    _player.meat++;
                    Debug.Log("meat added");
                    //add meat
                return;
            }
            if (canOpenHud)
            {
                if (!_isOpened)
                {
                    _input.SwitchActionMap(); 
                    _previousSelector = _selector;
                    _previousCG = _hudToOpen;
                }
                else
                {
                    _secondTab = true;
                }
                _hudToOpen.alpha = 1;
                _selector.ActBtn();
                _isOpened = true;
            }
        }

        public void CloseHud()
        {
            if (!_secondTab)
            {
                _input.SwitchActionMap();
                _hudToOpen.alpha = 0;
                _isOpened = false;
            }
            else
            {
                _hudToOpen.alpha = 0;
                _selector = _previousSelector;
                _selector.ActBtn();
                _secondTab = false;
                _hudToOpen.gameObject.SetActive(false);
                _hudToOpen = _previousCG;
            }
            
        }

        public void ClickBtn()
        {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable)
            {
                EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
    }
}