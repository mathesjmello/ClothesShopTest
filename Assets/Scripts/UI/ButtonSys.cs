
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonSys: MonoBehaviour
    {
        private Button _btn;
        [SerializeField] private int value;
        [SerializeField] private bool painelBtn;
        [SerializeField] private bool buySellBtn;
        [SerializeField] private CanvasGroup cg;
        [SerializeField] private BtnSelector btnSelector;
        private HUDController _hud;
        private BuySellSys _bs;
        private OutfitController _outfitC;
        private void Start()
        {
            _hud = Bootstrap.Instance.hudC;
            _bs = Bootstrap.Instance.buySellSys;
            _outfitC = Bootstrap.Instance.outfitC;
            _btn = GetComponent<Button>();
            _btn.onClick.AddListener(DoStuff);
        }

        private void DoStuff()
        {
            if (painelBtn)
            {
                cg.gameObject.SetActive(true);
                _hud.OnTriggerCheck(cg, btnSelector, 0);
                _hud.OpenHud();
            }else if (buySellBtn)
            {
                _bs.BuyOrSell(value);
            }
            else
            {
                _outfitC.ChangeOutfit(value);
            }
            
            
        }
    }
}