using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightShopUI : MonoBehaviour
{
    [SerializeField] private List<BookColumnUI> bookColumns = new List<BookColumnUI>();

    private void OnEnable() {
        EventHandler.UpdateNightShop += UpdateBookUI;
    }

    private void OnDisable() {
        EventHandler.UpdateNightShop -= UpdateBookUI;
    }

    private void UpdateBookUI(List<BookDetail> bookDetails)
    {
        if(bookColumns != null){
            foreach (var bookColumn in bookColumns)
            {
                if(bookColumn.BookParent != null){
                    foreach (Transform child in bookColumn.BookParent)
                    {
                        Destroy(child.gameObject);
                    }
                }
            }
        }

        foreach (var bookColumn in bookColumns)
        {
            foreach (var bookDetail in bookDetails)
            {
                if(bookDetail.bookType == bookColumn.BookType)
                    bookColumn.GenerateBookUI(bookDetail);
            }
        }
    }
}
