using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BookSlotUI : MonoBehaviour
{
    [SerializeField] private BookDetail bookDetail;
    public BookDetail BookDetail{
        get{ return bookDetail; }
    }

    private Image bookImage;
    private BookSlotUI book;
    private Button button;
    private int slotHash;

    private void OnEnable() {
        book = GetComponent<BookSlotUI>();
        button = GetComponent<Button>();
        bookImage = GetComponent<Image>();

        slotHash = this.GetHashCode();

        //点击事件注册
        button.onClick.AddListener(PickUpBook);

        EventHandler.AddBookToStorage += AddToStorage;
    }

    private void OnDisable() {
        button.onClick.RemoveAllListeners();

        EventHandler.AddBookToStorage -= AddToStorage;
    }

    public void InitBookSlotUI(BookDetail bookDetail){
        this.bookDetail = bookDetail;
        //TODO:创建视觉效果
    }

    private void AddToStorage(int slotHash)
    {
        if(this.slotHash != slotHash) return;
        StorageManager.Singleton.AddBook(book.BookDetail);
    }

    private void HideInScene(){
        bookImage.enabled = false;
    }

    public void PickUpBook(){
        //顺序
        EventHandler.CallAddBookToStorage(slotHash);
        EventHandler.CallUpdateStorageUI();

        HideInScene();
    }
}
