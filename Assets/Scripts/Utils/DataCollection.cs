using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 书的具体数据
/// </summary>
[System.Serializable]
public class BookDetail{
    public int bookId;
    public string bookName;
    public string bookIntro;
    // public Sprite bookIcon;
    public BookType bookType;
    public int price;
}

/// <summary>
/// NPC的买书请求
/// </summary>
[System.Serializable]
public class NPCRequest{
    /// <summary>
    /// 好感度基础值
    /// </summary>
    public int likeBase;
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
public class ItemDetail{
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
public class FurnitureDetail{
    public int furnitureId;
    public string furnitureName;
    public string furnitureIntro;
    public int price;
    public int demonstrationEffect;
    public bool isNewToPlayer;

}