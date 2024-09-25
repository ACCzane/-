using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BookList", menuName = "Data/BookList")]
public class BookList_SO : ScriptableObject
{
    public List<BookDetail> books;
    public Dictionary<int, BookDetail> booksDict = new Dictionary<int, BookDetail>();

    private void OnEnable() {
        EventHandler.UpdateBag_Book += UpdateBooksDict;
    }

    private void OnDisable() {
        EventHandler.UpdateBag_Book -= UpdateBooksDict;
    }

    private void OnValidate() {
        UpdateBooksDict();
        UpdateBookId();
    }

    /// <summary>
    /// 从0开始递增
    /// </summary>
    private void UpdateBookId(){
        for (int i = 0; i < books.Count; i++)
        {
            books[i].bookId = i;
        }
    }

    private void UpdateBooksDict() {
        if (books == null) return;
        foreach (var book in books) {
            booksDict[book.bookId] = book;
        }
    }
}
