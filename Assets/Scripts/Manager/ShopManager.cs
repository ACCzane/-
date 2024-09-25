using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Singleton{get; private set;}
    [SerializeField] private BookList_SO bookList_SO;
    private List<int> books;

    private void OnEnable() {
        books = new List<int>();

        if(Singleton != null) return;
        Singleton = this;
    }

    /// <summary>
    /// 获取随机的几本书，将作为一个玩家可购买的选项
    /// </summary>
    /// <param name="amount">书的数量</param>
    public List<int> GenerateBooks(int amount){
        books.Clear();

        for(int i = 0; i < amount; i++){
            int randomIndex = Random.Range(0, books.Count);
            books.Add(bookList_SO.books[randomIndex].bookId);
        }

        return books;
    }
}
