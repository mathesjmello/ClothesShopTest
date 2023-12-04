using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class HUDController : MonoBehaviour
    {
        private bool _isOpened;
        public bool _secondTab;
        public bool canOpenHud;
        private CanvasGroup _hudToOpen;
        public CanvasGroup _previousCG;
        public BtnSelector _selector;
        public BtnSelector _previousSelector;

        public void OnTriggerCheck(CanvasGroup hud, BtnSelector btnSelector)
        {
            canOpenHud = true;
            _hudToOpen = hud;
            _selector = btnSelector;
            
        }

        public void ExitTriggerCheck()
        {
            canOpenHud = false;
        }

        public void OpenHud()
        {
            if (canOpenHud)
            {
                if (!_isOpened)
                {
                    Bootstrap.Instance.inputM.SwitchActionMap(); 
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
                Bootstrap.Instance.inputM.SwitchActionMap();
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