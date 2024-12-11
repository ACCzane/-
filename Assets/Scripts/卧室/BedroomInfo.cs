using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Bedroom 
{    
    public class BedroomInfo : MonoBehaviour
    {
        [SerializeField] private TMP_Text timeText;

        private void OnEnable()
        {
            EventHandler.UpdateTimeUI += UpdateTimeUI_;
            EventHandler.CallTransferScene();
        }

        private void UpdateTimeUI_(int hour, int minute)
        {
            timeText.text = string.Format("{0:00}:{1:00}", hour, minute);
        }
    }
}


