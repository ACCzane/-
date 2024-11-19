using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

namespace BookSelling
{
    public class BooksBagUI : MonoBehaviour
    {
        [Header("引用")]
        private BookStorage bookStorage;
        [SerializeField] private int bagSlotAmount;
        [SerializeField] private int onSellSlotAmount;
        [SerializeField] private Slot[] bagSlots;
        [SerializeField] private Slot[] onSellSlots;

        //
        private BookType currentBookType;
        private int pageIndex;
        private int pageCount;
        private List<BookDetail> bagBookDetails;
        private List<BookDetail> onSellBookDetails => bookStorage.booksOnSell;

        //
        private BookSpawner bookSpawner;

        public bool CanOpen{get; private set;} = true;

        private void Awake() {
            bookStorage = GameData.GameSave.bookStorage;
        }

        private void Start() {
            //初始化格子index
            for(int i = 0; i < bagSlotAmount; i++){
                bagSlots[i].index = i;
            }
            for(int i = 0; i < onSellSlotAmount; i++){
                onSellSlots[i].index = i;
            }
            //Toggle默认option0
            SwitchBookType(0);
            //
            UpdateOnSellPage();
        }

        private void OnEnable() {
            EventHandler.AddBookToSell += OnAddBookToSell;
            EventHandler.RemoveBookFromSell += OnRemoveBookFromSell;
        }

        private void OnDisable() {
            EventHandler.AddBookToSell -= OnAddBookToSell;
            EventHandler.RemoveBookFromSell -= OnRemoveBookFromSell;
        }

        /// <summary>
        /// 根据BookType切换视图
        /// </summary>
        /// <param name="bookType"></param>
        public void SwitchBookType(BookType bookType){
            //根据种类更新当前BookDetail的Cache
            currentBookType = bookType;
            Debug.Log(bookType);
            bagBookDetails = bookStorage.GetBookDetails(false, currentBookType);

            //初始化，获取页面数量
            pageCount = bagBookDetails.Count / bagSlotAmount;

            //当前页面置0，并刷新页面
            UpdateBagPage(0);
        }

        /// <summary>
        /// 为了暴露给UGUI Toggle组件重构SwitchBookType方法
        /// </summary>
        /// <param name="bookType"></param>
        public void SwitchBookType(){
            int index = (int)currentBookType;
            index++;
            index %= 5;
            
            SwitchBookType((BookType)index);
        }

        /// <summary>
        /// 根据页面Index刷新UI元素
        /// </summary>
        /// <param name="pageIndex"></param>
        public void UpdateBagPage(int pageIndex){
            this.pageIndex = pageIndex;
            //根据页面Index更新Slots
            int count = bagBookDetails.Count > bagSlotAmount + bagSlotAmount * pageIndex ?
                bagSlotAmount : bagBookDetails.Count - bagSlotAmount * pageIndex;

            for(int i = 0; i < count; i++){
                bagSlots[i].UpdateSlot(bagBookDetails[i + bagSlotAmount * pageIndex]);
            }
            for(int i = count; i < bagSlotAmount; i++){
                bagSlots[i].SetDefault();
            }
        }

        public void UpdateOnSellPage(){
            int count = onSellBookDetails.Count;
            for(int i = 0; i < count; i++){
                onSellSlots[i].UpdateSlot(onSellBookDetails[i]);
            }
            for(int i = count; i < onSellSlotAmount; i++){
                onSellSlots[i].SetDefault();
            }
        }

        public void TurnPreviousPage(){
            if(pageIndex - 1 < 0){
                return;
            }
            UpdateBagPage(pageIndex-1);
        }

        public void TurnNextPage(){
            if(pageIndex + 1 >= pageCount){
                return;
            }
            UpdateBagPage(pageIndex+1);
        }

        public void OnAddBookToSell(int index){
            //如果OnSell格子放满了
            if(onSellBookDetails.Count == onSellSlotAmount){
                //TODO:视觉回馈
                return;
            }

            //如果还能放
            //SO数据处理
            bookStorage.booksInStorage.Remove(bagSlots[index].bookDetail);
            bookStorage.booksOnSell.Add(bagSlots[index].bookDetail);

            //根据种类更新当前BookDetail的Cache
            bagBookDetails = bookStorage.GetBookDetails(false, currentBookType);
            //初始化，获取页面数量
            if(bagBookDetails.Count / bagSlotAmount < pageCount){
                //如果页面减少
                pageCount = bagBookDetails.Count / bagSlotAmount;
                UpdateBagPage(pageIndex-1);
            }else{
                UpdateBagPage(pageIndex);
            }

            UpdateOnSellPage();
        }

        public void OnRemoveBookFromSell(int index){
            bookStorage.booksOnSell.Remove(onSellSlots[index].bookDetail);
            bookStorage.booksInStorage.Add(onSellSlots[index].bookDetail);

            //根据种类更新当前BookDetail的Cache
            bagBookDetails = bookStorage.GetBookDetails(false, currentBookType);
            //初始化，获取页面数量
            if(bagBookDetails.Count / bagSlotAmount > pageCount){
                //如果页面增加
                pageCount = bagBookDetails.Count / bagSlotAmount;
                UpdateBagPage(pageIndex+1);
            }else{
                UpdateBagPage(pageIndex);
            }

            UpdateOnSellPage();
        }

        public void QuitUIEnterScene(){
            List<BookDetail> books = new List<BookDetail>(onSellBookDetails);

            bookSpawner.SpawnBooks(books);
            gameObject.SetActive(false);

            //更新数据库，已经送往书架的书不会返回（即使当天没有卖出）
            //关闭UI打开面板，当天无法再打开

            bookStorage.booksOnSell.Clear();
            CanOpen = false;
        }
        public void EnterUI(BookSpawner bookSpawner){
            this.bookSpawner = bookSpawner;
            gameObject.SetActive(true);
        }
    }

}

