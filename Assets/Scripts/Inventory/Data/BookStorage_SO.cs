using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New BookStorage", menuName = "Bag/BookStorage")]
public class BookStorage_SO : ScriptableObject
{
    /// <summary>
    /// 玩家金钱，懒得单独创建了，一起放在这个SO里
    /// </summary>
    public int playerCoin;

    // public int defaultCapacity = 5;
    public List<BookDetail> books;
    public List<BookDetail> books_children => books.Where(
        book => book.bookType == BookType.Children).ToList();
    
    public List<BookDetail> books_literacy => books.Where(
        book => book.bookType == BookType.Literacy).ToList();

    public List<BookDetail> books_Love => books.Where(
        book => book.bookType == BookType.Love).ToList();

    public List<BookDetail> books_Photography => books.Where(
        book => book.bookType == BookType.Photography).ToList();

    public List<BookDetail> books_Science => books.Where(
        book => book.bookType == BookType.Science).ToList();

    private void Update() {
        Debug.Log(books_children.Count);
    }
}
