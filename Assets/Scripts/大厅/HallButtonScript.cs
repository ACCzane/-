using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HallButtonScript : MonoBehaviour
{
    [Header("按钮引用")]
    [SerializeField] private Button sellButton;
    [SerializeField] private Button bedButton;
    [SerializeField] private Button buyButton;

    void Start()
    {
        sellButton.onClick.AddListener(
            () => { SceneLoadManager.Singleton.LoadScene("卖书场景"); });
        bedButton.onClick.AddListener(
            () => { SceneLoadManager.Singleton.LoadScene("-1"); });
        buyButton.onClick.AddListener(
            () => { SceneLoadManager.Singleton.LoadScene("NightShop"); });
    }

    void Update()
    {
    }
}
