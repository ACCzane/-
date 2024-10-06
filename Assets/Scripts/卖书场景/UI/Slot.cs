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

        public void UpdateSlot(BookDetail bookDetail){
            this.bookDetail = bookDetail;
            gameObject.SetActive(true);
            bookName.text = bookDetail.bookName;
            // icon.sprite = bookDetail.bookIcon;
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

