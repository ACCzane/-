using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BookSelling
{
    public class BookSlot : MonoBehaviour, IPointerClickHandler
    {
        private BookDetail bookDetail;
        private bool hasBook = false;

        public void GetBook(BookDetail bookDetail){
            this.bookDetail = bookDetail;

            hasBook = true;
        }

        /// <summary>
        /// 点击书本售卖
        /// </summary>
        /// <param name="eventData"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void OnPointerClick(PointerEventData eventData)
        {
            if(hasBook){
                //槽位中有书，点击弹出售卖UI
            }
            //槽位中没书
            return;
        }
    }
}

