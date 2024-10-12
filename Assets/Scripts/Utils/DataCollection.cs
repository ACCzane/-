using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

/// <summary>
/// 书的具体数据
/// </summary>
[System.Serializable]
public class BookDetail
{
    public int bookId;
    public string bookName;
    public string bookIntro;
    public BookType bookType;
    public int price;
}

// /// <summary>
// /// 在收纳箱的同类书的集合
// /// </summary>
// [System.Serializable]
// public class BookPile{
//     public int capacity;
//     public BookType bookType;
//     public List<int> bookIds;
//     public BookPile(int capacity){
//         this.capacity = capacity;
//     }
// }

/// <summary>
/// 游戏加成道具的具体数据
/// </summary>
[System.Serializable]
public class ItemDetail
{
    public int itemId;
    public string itemName;
    public string itemintro;
    public int price;
    public bool isNewToPlayer;
    public int stackableAmount;
}

/// <summary>
/// 家具的具体数据
/// </summary>
[System.Serializable]
public class FurnitureDetail
{
    [ShowAssetPreview]
    public GameObject[] prefab;

    public FurnitureType furnitureType;

    public enum FurnitureType
    {
        Floor, Wall
    }
}