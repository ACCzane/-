using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAssetUI : MonoBehaviour
{
    private PlayerAsset playerAsset;

    [SerializeField] private TMPro.TMP_Text moneyText;


    private void Awake() {
        playerAsset = GameData.GameSave.playerAsset;
        EventHandler.CallUpdatePlayerMoney(playerAsset.money);
    }

    private void OnEnable() {
        EventHandler.UpdatePlayerMoney += OnUpdatePlayerMoney;
    }

    private void OnDisable() {
        EventHandler.UpdatePlayerMoney -= OnUpdatePlayerMoney;
    }

    private void OnUpdatePlayerMoney(int playerMoney)
    {
        moneyText.text = playerMoney.ToString();
    }
}
