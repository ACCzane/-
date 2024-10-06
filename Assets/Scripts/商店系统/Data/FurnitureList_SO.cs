using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FurnitureList", menuName = "Data/FurnitureList")]
public class FurnitureList_SO : ScriptableObject
{
    public List<FurnitureDetail> furnitures;
    public Dictionary<int, FurnitureDetail> furnituresDict = new Dictionary<int, FurnitureDetail>();

    // private void OnEnable() {
    //     EventHandler.UpdateBag_Book += UpdateBooksDict;
    // }

    // private void OnDisable() {
    //     EventHandler.UpdateBag_Book -= UpdateBooksDict;
    // }

    private void OnValidate() {
        UpdateFurnitureId();
        UpdateFurnituresDict();
    }

    /// <summary>
    /// 从0开始递增
    /// </summary>
    private void UpdateFurnitureId(){
        for (int i = 0; i < furnitures.Count; i++)
        {
            furnitures[i].furnitureId = i;
        }
    }

    private void UpdateFurnituresDict() {
        if (furnitures == null) return;
        foreach (var furniture in furnitures) {
            furnituresDict[furniture.furnitureId] = furniture;
        }
    }
}
