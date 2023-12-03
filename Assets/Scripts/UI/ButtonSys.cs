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

        private void Start()
        {
            _btn = GetComponent<Button>();
            _btn.onClick.AddListener(DoStuff);
        }

        private void DoStuff()
        {
            if (painelBtn)
            {
                //open select next painel
            }
            else
            {
                Bootstrap.Instance.outfitC.ChangeOutfit(value);
            }
            
            
        }
    }
}