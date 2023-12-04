using System;
using Unity.VisualScripting;
using UnityEngine;

namespace UI
{
    public class TriggerCheck: MonoBehaviour
    {
        public GameObject helpHUD;
        public CanvasGroup hudToOpen;
        public BtnSelector btn;
        public int collect;
        private HUDController _hud;

        private void Start()
        {
            _hud = Bootstrap.Instance.hudC;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            helpHUD.SetActive(true);
            helpHUD.transform.SetParent(transform);
            var newpos = Vector3.zero;
            newpos += Vector3.up;
            helpHUD.transform.localPosition = newpos;
            _hud.OnTriggerCheck(hudToOpen, btn,collect);
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            _hud.ExitTriggerCheck();
            helpHUD.SetActive(false);
        }
    }
}