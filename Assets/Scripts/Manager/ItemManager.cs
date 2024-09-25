using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Singleton{get; private set;}

    [SerializeField] private BookList_SO bookList_SO;

    private void OnEnable() {
        if(Singleton!=null) return;
        Singleton = this;
    }

    public BookDetail GetBookDetailById(int bookId){
        if(bookList_SO!=null) return null;

        if(bookList_SO.booksDict[bookId] == null) return null;

        return bookList_SO.booksDict[bookId];
    }

    //TODO:加成道具数据结构
    public PropDetail GetPropDetailById(int propId){
        return null;
    }
}
