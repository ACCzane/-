using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookColumnUI : MonoBehaviour
{
    [SerializeField] private Transform bookParent;
    public Transform BookParent{
        get{return bookParent;}
    }
    [Range(3,5)][SerializeField] private int bookAmount;
    private List<BookSlotUI> books;
    [SerializeField] private BookType bookType;
    public BookType BookType{
        get{return bookType;}
    }

    public void GenerateBookUI(BookDetail bookDetail){
        ItemUIManager.Singleton.GenerateBookUIByDetail(bookDetail,BookParent);
    }
}
