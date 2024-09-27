using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemList", menuName = "Data/ItemList")]
public class ItemList_SO : ScriptableObject
{
    public List<ItemDetail> items;
    public Dictionary<int, ItemDetail> itemsDict = new Dictionary<int, ItemDetail>();

    private void OnEnable() {
        EventHandler.UpdateBag_Item += UpdateItemsDict;
    }

    private void OnDisable() {
        EventHandler.UpdateBag_Book -= UpdateItemsDict;
    }

    private void OnValidate() {
        UpdateItemId();
        UpdateItemsDict();
    }

    /// <summary>
    /// 从0开始递增
    /// </summary>
    private void UpdateItemId(){
        for (int i = 0; i < items.Count; i++)
        {
            items[i].itemId = i;
        }
    }

    private void UpdateItemsDict() {
        if (items == null) return;
        foreach (var item in items) {
            itemsDict[item.itemId] = item;
        }
    }
}
