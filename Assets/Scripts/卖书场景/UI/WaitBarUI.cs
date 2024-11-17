using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitBarUI : MonoBehaviour
{
    [SerializeField] private Image image;

    private void OnEnable() {
        EventHandler.NPCWaitTimeRatioUpdate += OnNPCWaitTimeRatioUpdate;
    }

    private void OnDisable() {
        EventHandler.NPCWaitTimeRatioUpdate -= OnNPCWaitTimeRatioUpdate;
    }

    private void OnNPCWaitTimeRatioUpdate(float ratio)
    {
        image.fillAmount = ratio;
    }
}
