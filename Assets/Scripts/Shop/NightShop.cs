using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NightShop : MonoBehaviour
{
    [SerializeField] private BookList_SO bookList_SO;
    private List<BookDetail> books;

    private void OnEnable() {
        books = new List<BookDetail>();
    }

    /// <summary>
    /// 刷新夜晚商店，商品更新
    /// </summary>
    public void UpdateNightShop(){
        //TODO:暂定，等策划
        int bookAmountOfType = 3;

        books.Clear();

        foreach(BookType bookType in Enum.GetValues(typeof(BookType))){
            //每种书拿n本
            List<BookDetail> booksOfType = bookList_SO.books.Where(
                book => book.bookType == bookType).ToList();

            for(int i=0;i<bookAmountOfType;i++){
                books.Add(GetRandomBook(booksOfType));
            }
        }
        
        EventHandler.CallUpdateNightShop(books);
        Debug.Log("Event Called");
    }

    private BookDetail GetRandomBook(List<BookDetail> books){
        int randomNum = UnityEngine.Random.Range(0, books.Count-1);
        return books[randomNum];
    }

    // /// <summary>
    // /// 获取随机的几本书，将作为一个玩家可购买的选项, 弃用，策划又不当人辣
    // /// </summary>
    // /// <param name="amount">书的数量</param>
    // public List<int> GenerateBooks(int amount){
    //     books.Clear();

    //     for(int i = 0; i < amount; i++){
    //         int randomIndex = Random.Range(0, books.Count);
    //         books.Add(bookList_SO.books[randomIndex].bookId);
    //     }

    //     return books;
    // }
}
