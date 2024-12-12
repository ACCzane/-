using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BookSelling
{
    public class InfoPanelUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text timeText;
        [SerializeField] private TMP_Text coinText;
        [SerializeField] private Image NPCWaitBar;
        [SerializeField] private TMP_Text likeText;

        private void OnEnable() {
            EventHandler.UpdateTimeUI += UpdateTimeUI;
            EventHandler.UpdatePlayerMoney += OnUpdatePlayerMoney;
            EventHandler.PlayerLikesChanged += OnPlayerLikesChanged;
            EventHandler.CallTransferScene("¬Ù È≥°æ∞");
        }

        private void OnDisable() {
            EventHandler.UpdateTimeUI -= UpdateTimeUI;
            EventHandler.UpdatePlayerMoney -= OnUpdatePlayerMoney;
            EventHandler.PlayerLikesChanged -= OnPlayerLikesChanged;
        }

        private void OnPlayerLikesChanged(int playerLikes)
        {
            likeText.text = playerLikes.ToString();
        }

        private void OnUpdatePlayerMoney(int playerMoney)
        {
            coinText.text = playerMoney.ToString();
        }

        private void UpdateTimeUI(int hour, int minute)
        {
            timeText.text = string.Format("{0:00}:{1:00}", hour, minute);
        }
    }

}
