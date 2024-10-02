using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NightShop : MonoBehaviour
{
    [SerializeField] private BookList_SO bookList_SO;
    [SerializeField] private BookStorage_SO bookStorage_SO;
    private List<BookDetail> books;
    private int playerCoin;

    private void OnEnable() {
        books = new List<BookDetail>();

        EventHandler.AddBookToStorage += AddToStorage;
    }

    private void OnDisable() {
        EventHandler.AddBookToStorage -= AddToStorage;
    }

    private void AddToStorage(BookSlotUI book)
    {
        bookStorage_SO.books.Add(book.BookDetail);
    }

    /// <summary>
    /// 刷新夜晚商店，商品更新，商品数据存在私有变量books中
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

    /// <summary>
    /// 随机从存储了所有书本信息的bookList_SO中取一个BookDetail
    /// </summary>
    /// <param name="books"></param>
    /// <returns></returns>
    private BookDetail GetRandomBook(List<BookDetail> books){
        int randomNum = UnityEngine.Random.Range(0, books.Count-1);
        return books[randomNum];
    }

}
