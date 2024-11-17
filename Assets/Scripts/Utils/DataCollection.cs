using System;
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
    // public Sprite bookIcon;
    public BookType bookType;
    public int price;
    //售出价值/购入价值
    public float sellRatio = 1.5f;
}

/// <summary>
/// NPC的买书请求
/// </summary>
[System.Serializable]
public class NPCRequest{
    /// <summary>
    /// 好感度基础值
    /// </summary>
    public int likeBase = 1;
    public string requestText;
    public RequestType requestType;
    public BookType bookType;
    public List<string> bookName;
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
    // [ShowAssetPreview]
    // public GameObject[] prefab;

    [ShowAssetPreview]
    public Sprite[] sprites;

    public FurnitureType furnitureType;

    public enum FurnitureType
    {
        Floor, Wall
    }
}