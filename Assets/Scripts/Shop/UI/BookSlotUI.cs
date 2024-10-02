using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 商店系统中，可以点击购买的书本
/// </summary>
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

        // EventHandler.AddBookToStorage += AddToStorage;
    }

    private void OnDisable() {
        button.onClick.RemoveAllListeners();

        // EventHandler.AddBookToStorage -= AddToStorage;
    }

    public void InitBookSlotUI(BookDetail bookDetail){
        this.bookDetail = bookDetail;
        //TODO:创建视觉效果
    }

    public void HideInScene(){
        bookImage.enabled = false;
    }

    public void PickUpBook(){
        //BookStorage添加数据，这个事件被注册的方法中会执行金币判断操作
        EventHandler.CallAddBookToStorage(book);
        //更新UI
        EventHandler.CallUpdateStorageUI();
    }
}
