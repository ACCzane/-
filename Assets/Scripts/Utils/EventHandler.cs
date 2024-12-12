using System;
using System.Collections;
using System.Collections.Generic;
using BookSelling;
using UnityEngine;

public static class EventHandler
{
    //检查场景转换
    public static event Action<string> TransferScene;
    public static void CallTransferScene(string _sceneName){
        TransferScene?.Invoke(_sceneName);
    }

    //数据处理
    public static event Action UpdateBag_Book;
    public static void CallUpdateBag_Book(){
        UpdateBag_Book?.Invoke();
    }
    
    public static event Action UpdateBag_Item;
    public static void CallUpdateBag_Item(){
        UpdateBag_Book?.Invoke();
    }

    public static event Action<int> UpdatePlayerMoney;
    public static void CallUpdatePlayerMoney(int money){
        UpdatePlayerMoney?.Invoke(money);
    }

    #region 夜间商店系统
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
    #endregion

    #region 卖书系统
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

    public static Action<NPCRequest> NPCSpawn;
    public static void CallNPCSpawn(NPCRequest npcRequest){
        NPCSpawn?.Invoke(npcRequest);
    }

    //为了使书有npc的数据，方便点击事件查找
    public static Action<NPC> LinkBooksToNPC;
    public static void CallLinkBooksToNPC(NPC npc){
        LinkBooksToNPC?.Invoke(npc);
    }

    public static Action<float> NPCWaitTimeRatioUpdate;
    public static void CallNPCWaitTimeUpdate(float ratio){
        NPCWaitTimeRatioUpdate?.Invoke(ratio);
    }

    public static Action NPCRemove;
    public static void CallNPCRemove(){
        NPCRemove?.Invoke();
    }

    public static Action<BookDetail, bool> OpenBookTipOverlayScreenUI;
    public static void CallOpenBookTipOverlayScreenUI(BookDetail bookDetail, bool isOpen){
        OpenBookTipOverlayScreenUI?.Invoke(bookDetail, isOpen);
    }

    public static Action<BookDetail, bool> OpenAcceptButton;
    public static void CallOpenAcceptButton(BookDetail bookDetail, bool isOpen){
        OpenAcceptButton?.Invoke(bookDetail, isOpen);
    }

    public static Action<BookDetail> ClickAcceptButton;
    public static void CallClickAcceptButton(BookDetail bookDetail){
        ClickAcceptButton?.Invoke(bookDetail);
    }

    //解决多个书本可以被同时选中的问题
    public static Action<BookItem> UnSelectOtherBooks;
    public static void CallUnSelectOtherBooks(BookItem bookItem){
        UnSelectOtherBooks?.Invoke(bookItem);
    }
    
    public static Action<int, int, int> Trade;
    public static void CallTrade(int gainedMoney, int elfCoin, int npcFavorability){
        Trade?.Invoke(gainedMoney, elfCoin, npcFavorability);
    }

    public static Action<int> PlayerLikesChanged;
    public static void CallPlayerLikesChanged(int playerLikes){
        PlayerLikesChanged?.Invoke(playerLikes);
    }
    #endregion
}
