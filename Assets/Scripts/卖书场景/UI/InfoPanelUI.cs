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
        [SerializeField] private Image likeBar;

        private void OnEnable() {
            EventHandler.UpdateTimeUI += UpdateTimeUI;
        }

        private void OnDisable() {
            EventHandler.UpdateTimeUI -= UpdateTimeUI;
        }

        private void UpdateTimeUI(int hour, int minute)
        {
            timeText.text = hour + ":" + minute;
        }
    }

}
