using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler
{
    public static event Action TransferScene;
    public static void CallinteractType(){
        TransferScene?.Invoke();
    }

    //SO数据处理
    public static event Action UpdateBag_Book;
    public static void CallUpdateBag_Book(){
        UpdateBag_Book?.Invoke();
    }
    
    public static event Action UpdateBag_Item;
    public static void CallUpdateBag_Item(){
        UpdateBag_Book?.Invoke();
    }


    //夜间商店系统
    public static event Action<List<BookDetail>> UpdateNightShop;
    public static void CallUpdateNightShop(List<BookDetail> bookDetails){
        UpdateNightShop?.Invoke(bookDetails);
    }

    public static event Action<BookSlotUI> AddBookToStorage;
    public static void CallAddBookToStorage(BookSlotUI book){
        AddBookToStorage?.Invoke(book);
    }

    public static event Action UpdateStorageUI;
    public static void CallUpdateStorageUI(){
        UpdateStorageUI?.Invoke();
    }

    //卖书系统
    public static Action<int> AddBookToSell;
    public static void CallAddBookToSell(int index){
        AddBookToSell?.Invoke(index);
    }

    public static Action<int> RemoveBookFromSell;
    public static void CallRemoveBookFromSell(int index){
        RemoveBookFromSell?.Invoke(index);
    }

    public static Action<int, int> UpdateTimeUI;
    public static void CallUpdateTimeUI(int hour, int minute){
        UpdateTimeUI?.Invoke(hour, minute);
    }

    public static Action<NPCRequest> NPCRequestForBook;
    public static void CallNPCRequestForBook(NPCRequest npcRequest){
        NPCRequestForBook?.Invoke(npcRequest);
    }

    public static Action<BookDetail, bool> OpenBookTipOverlayScreenUI;
    public static void CallOpenBookTipOverlayScreenUI(BookDetail bookDetail, bool isOpen){
        OpenBookTipOverlayScreenUI?.Invoke(bookDetail, isOpen);
    }
}
