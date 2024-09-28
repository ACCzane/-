using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StorageManager : MonoBehaviour
{
    public static StorageManager Singleton{get; private set;}
    [SerializeField] private BookStorage_SO bookStorage_SO;

    private void OnEnable() {
        if (Singleton != null) return;
        Singleton = this;
    }

    public void AddBook(BookDetail bookDetail){
        bookStorage_SO.books.Add(bookDetail);
    }
}
