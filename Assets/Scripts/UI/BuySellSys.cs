using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BuySellSys : MonoBehaviour
    {
        public int outfit1Value = 10, outfit2Value = 20;
        public Button outfit1Buy, outfit2Buy, egg , meat;
        public Button outfit1, outfit2;
        public TextMeshProUGUI moneyText;
        private int _playerMoney;
        private int _playerEggs;
        private int _playerMeat;

        private void Start()
        {
            CheckPlayerMoney();
            CheckPlayerItems();
        }

        private void CheckPlayerMoney()
        {
            _playerMoney = Bootstrap.Instance.pC.money;
            moneyText.text = "Coins:   "+_playerMoney.ToString();
            outfit1Buy.interactable = outfit1Value <= _playerMoney;

            outfit2Buy.interactable = outfit2Value <= _playerMoney;
            
        }

        private void CheckPlayerItems()
        {
            _playerEggs = Bootstrap.Instance.pC.eggs;
            _playerMeat = Bootstrap.Instance.pC.meat;
            meat.interactable = _playerMeat >= 1;
            egg.interactable = _playerEggs >= 1;
        }

        public void BuyOrSell(int value)
        {
            switch (value)
            {
                case 2:
                    Bootstrap.Instance.pC.eggs--;
                    break;
                case 5:
                    Bootstrap.Instance.pC.meat--;
                    break;
                case -10:
                    outfit1.interactable = true;
                    break;
                case -20:
                    outfit2.interactable = true;
                    break;
            }

            Bootstrap.Instance.pC.money += value;
            
            CheckPlayerMoney();
            CheckPlayerItems();
        }
    }
}