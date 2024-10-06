using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIManager : MonoBehaviour
{
    public static ItemUIManager Singleton{get; private set;}

    [SerializeField] private GameObject bookUIPrefab;
    [SerializeField] private BookTipUI bookTipUI;

    private Dictionary<BookType, Color> bookColors = new Dictionary<BookType,Color>();

    private void OnEnable() {
        if (Singleton != null) return;
        Singleton = this;

        bookTipUI.gameObject.SetActive(false);

        //初始化字典
        bookColors[BookType.Literacy] = Color.red;
        bookColors[BookType.Children] = Color.yellow;
        bookColors[BookType.Love] = Color.white;
        bookColors[BookType.Photography] = Color.gray;
        bookColors[BookType.Science] = Color.blue;
    }

    /// <summary>
    /// 根据bookDetail生成对应的UI
    /// </summary>
    /// <param name="bookId"></param>
    /// <param name="parent">具有layoutgroup的父物体</param>
    /// <returns></returns>
    public BookSlotUI GenerateBookUIByDetail(BookDetail bookDetail, Transform parent){
        // if(bookList_SO == null) return null;
        BookSlotUI bookSlotUI = Instantiate(bookUIPrefab, parent).GetComponent<BookSlotUI>();
        //给bookSlotUI初始化
        bookSlotUI.InitBookSlotUI(bookDetail);
        //TODO:前期没有美术素材，用颜色做区分
        bookSlotUI.GetComponent<Image>().color = bookColors[bookSlotUI.BookDetail.bookType];
        return bookSlotUI;
    }

    /// <summary>
    /// 根据BookDetail以及世界坐标显示BookTip, 最后一个参数控制开关
    /// </summary>
    /// <param name="bookDetail"></param>
    /// <param name="pos"></param>
    /// <param name="show"></param>
    public void ShowBookTipUIAtWorldPos(BookDetail bookDetail, Vector2 pos, bool show){
        if(show == false){
            bookTipUI.gameObject.SetActive(false);
            return;
        }

        if(bookDetail==null) return;

        bookTipUI.SetupBookTip(bookDetail);

        bookTipUI.gameObject.SetActive(true);

        Vector2 offsetPos = new Vector2(50,-50);
        bookTipUI.GetComponent<RectTransform>().
            position = pos + offsetPos;
    }
}
