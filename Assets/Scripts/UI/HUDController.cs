using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class HUDController : MonoBehaviour
    {
        public bool canOpenHud;
        private CanvasGroup _hudToOpen;
        private BtnSelector _selector;

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
                Bootstrap.Instance.inputM.SwitchActionMap();
                _hudToOpen.alpha = 1;
                _selector.ActBtn();
            }
        }

        public void CloseHud()
        {
            Bootstrap.Instance.inputM.SwitchActionMap();
            _hudToOpen.alpha = 0;
        }

        public void ClickBtn()
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
        }
    }
}