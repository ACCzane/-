using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BookSelling
{
    public class Slot : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private TMP_Text bookName;
        [SerializeField] private Image icon;
        [SerializeField] private SlotType slotType;

        public int index;
        public BookDetail bookDetail;


        private Dictionary<BookType, string> bookTypeToSpritePathDict = new Dictionary<BookType,string>();


        private void OnEnable() {
            //初始化字典
            bookTypeToSpritePathDict[BookType.Literacy] = "进货商店/书图标/red-";
            bookTypeToSpritePathDict[BookType.Children] = "进货商店/书图标/while-";
            bookTypeToSpritePathDict[BookType.Love] = "进货商店/书图标/yellow-";
            bookTypeToSpritePathDict[BookType.Photography] = "进货商店/书图标/red-";
            bookTypeToSpritePathDict[BookType.Science] = "进货商店/书图标/red-";
        }


        public void UpdateSlot(BookDetail bookDetail){
            this.bookDetail = bookDetail;
            gameObject.SetActive(true);
            bookName.text = bookDetail.bookName;

            string assetPath = bookTypeToSpritePathDict[bookDetail.bookType];
            Sprite targetSprite = Resources.Load<Sprite>(assetPath);

            icon.sprite = targetSprite;
        }
        public void SetDefault(){
            bookDetail = null;
            gameObject.SetActive(false);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(slotType == SlotType.Bag)
                EventHandler.CallAddBookToSell(index);
            if(slotType == SlotType.OnSell)
                EventHandler.CallRemoveBookFromSell(index);
        }
    }
}

