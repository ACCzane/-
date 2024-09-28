using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NightShopScreen : MonoBehaviour
{
    private VisualElement rootVisualElement;
    private void Awake() {
        rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
    }
}
