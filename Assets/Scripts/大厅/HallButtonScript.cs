using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HallButtonScript : MonoBehaviour
{
    [Header("´óÌü")]
    [SerializeField] private Button sellButton;
    [SerializeField] private Button bedButton;
    [SerializeField] private Button buyButton;

    void Start()
    {
        sellButton.onClick.AddListener(
            () => { SceneLoadManager.Singleton.LoadScene("ÂôÊé³¡¾°"); });
        bedButton.onClick.AddListener(
            () => { SceneLoadManager.Singleton.LoadScene("-1"); });
        buyButton.onClick.AddListener(
            () => { SceneLoadManager.Singleton.LoadScene("NightShop"); });
    }

    void Update()
    {
    }
}
