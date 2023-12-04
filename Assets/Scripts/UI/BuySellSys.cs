using System;
using Player;
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
        private PlayerController _player;

        private void Start()
        {
            _player = Bootstrap.Instance.pC;
            CheckPlayerMoney();
            CheckPlayerItems();
        }

        private void CheckPlayerMoney()
        {
            _playerMoney = _player.money;
            moneyText.text = "Coins:   "+_playerMoney.ToString();
            outfit1Buy.interactable = outfit1Value <= _playerMoney;

            outfit2Buy.interactable = outfit2Value <= _playerMoney;
            
        }

        private void CheckPlayerItems()
        {
            _playerEggs = _player.eggs;
            _playerMeat = _player.meat;
            meat.interactable = _playerMeat >= 1;
            egg.interactable = _playerEggs >= 1;
        }

        public void BuyOrSell(int value)
        {
            switch (value)
            {
                case 2:
                    _player.eggs--;
                    break;
                case 5:
                    _player.meat--;
                    break;
                case -10:
                    outfit1.interactable = true;
                    break;
                case -20:
                    outfit2.interactable = true;
                    break;
            }

            _player.money += value;
            
            CheckPlayerMoney();
            CheckPlayerItems();
        }
    }
}