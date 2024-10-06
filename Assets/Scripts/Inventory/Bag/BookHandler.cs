using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 与书本进行逻辑交互
/// </summary>
public class BookHandler : MonoBehaviour
{
    /// <summary>
    /// 背包_书籍
    /// </summary>
    private BookStorage bag_Book = GameData.GameSave.bookStorage;

    /// <summary>
    /// 将book添加到背包(已废)
    /// </summary>
    /// <param name="bookItem"></param>
    public void AddBookToBookStorage(BookItem bookItem){
        //策划改了
        // foreach (var bookPile in bag_Book.books)
        // {
        //     //遍历找到对应种类的书堆
        //     if(bookPile.bookType == ItemManager.Singleton.GetBookDetailById(bookItem.bookId).bookType){
        //         //如果还有空位
        //         if(bookPile.bookIds.Count < bookPile.capacity){
        //             //添加该book到书堆
        //             bookPile.bookIds.Add(bookItem.bookId);

        //             EventHandler.CallUpdateBag_Book();
        //         }
        //         //如果没有空位
        //         else{

        //         }
        //     }
        // }
    }

    /// <summary>
    /// 将book从背包移除(已废)
    /// </summary>
    /// <param name="bookItem"></param>
    public void RemoveBookAtBookStorage(BookItem bookItem){
        // foreach (var bookPile in bag_Book.books)
        // {
        //     //遍历找到对应种类的书堆
        //     if(bookPile.bookType == ItemManager.Singleton.GetBookDetailById(bookItem.bookId).bookType){
        //         foreach (var bookId in bookPile.bookIds)
        //         {
        //             //如果有这本书的信息
        //             if(bookId == bookItem.bookId){
        //                 bookPile.bookIds.Remove(bookItem.bookId);

        //                 EventHandler.CallUpdateBag_Book();
        //             }
        //             //如果没有这本书的信息
        //             else{
                        
        //             }
        //         }
        //     }
        // }
    }


}
