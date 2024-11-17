using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BookStorage
{
    /// <summary>
    /// 存储在仓库中的书
    /// </summary>
    public List<BookDetail> booksInStorage = new List<BookDetail>();
    /// <summary>
    /// 在售卖的书
    /// </summary>
    public List<BookDetail> booksOnSell = new List<BookDetail>();

    /// <summary>
    /// 获得仓库或正在出售的特定种类的书的集合
    /// </summary>
    /// <param name="stat">1表示在出售,0表示在仓库</param>
    /// <param name="bookType"></param>
    public List<BookDetail> GetBookDetails(bool stat, BookType bookType){
        if(stat == false){
            return booksInStorage.Where((book) => book.bookType == bookType).ToList();
        }
        return booksOnSell.Where(book => book.bookType == bookType).ToList();
    }


}
