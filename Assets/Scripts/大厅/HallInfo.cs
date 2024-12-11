using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HallInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;

    private void OnEnable()
    {
        EventHandler.UpdateTimeUI += _UpdateTimeUI;
        EventHandler.CallTransferScene();
    }

    private void _UpdateTimeUI(int hour, int minute)
    {
        timeText.text = string.Format("{0:00}:{1:00}", hour, minute);
    }
}
