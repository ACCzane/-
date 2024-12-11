using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HallButtonScript : MonoBehaviour
{
    [Header("´óÌü")]
    [SerializeField] private Button buyButton;
    [SerializeField] private Button bedButton;
    [SerializeField] private Button underButton;

    void Start()
    {
        buyButton.onClick.AddListener(
            () => { SceneLoadManager.Singleton.LoadScene("ÂôÊé³¡¾°"); });
        bedButton.onClick.AddListener(
            () => { SceneLoadManager.Singleton.LoadScene("-1"); });
        underButton.onClick.AddListener(
            () => { SceneLoadManager.Singleton.LoadScene("NightShop"); });
    }

    void Update()
    {
    }
}
