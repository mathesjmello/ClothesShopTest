using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonSys: MonoBehaviour
    {
        private Button _btn;
        [SerializeField] private int value;
        [SerializeField] private bool painelBtn;
        [SerializeField] private CanvasGroup cg;
        [SerializeField] private BtnSelector btnSelector;
        private void Start()
        {
            _btn = GetComponent<Button>();
            _btn.onClick.AddListener(DoStuff);
        }

        private void DoStuff()
        {
            if (painelBtn)
            {
                cg.gameObject.SetActive(true);
                Bootstrap.Instance.hudC.OnTriggerCheck(cg, btnSelector);
                Bootstrap.Instance.hudC.OpenHud();
            }
            else
            {
                Bootstrap.Instance.outfitC.ChangeOutfit(value);
            }
            
            
        }
    }
}