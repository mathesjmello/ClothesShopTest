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
        public void OnTriggerEnter2D(Collider2D other)
        {
            helpHUD.SetActive(true);
            helpHUD.transform.SetParent(transform);
            var newpos = Vector3.zero;
            newpos += Vector3.up;
            helpHUD.transform.localPosition = newpos;
            Bootstrap.Instance.hudC.OnTriggerCheck(hudToOpen, btn);
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            Bootstrap.Instance.hudC.ExitTriggerCheck();
        }
    }
}