using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIManager : MonoBehaviour, IImageLoader
{
    public static ItemUIManager Singleton{get; private set;}

    

    [SerializeField] private GameObject bookUIPrefab;
    [SerializeField] private BookTipUI bookTipUI;

    private Dictionary<BookType, string> bookTypeToSpritePathDict = new Dictionary<BookType,string>();
    public Dictionary<BookType, string> BookTypeToSpritePathDict => bookTypeToSpritePathDict;

    private void OnEnable() {
        if (Singleton != null) return;
        Singleton = this;

        bookTipUI.gameObject.SetActive(false);

        InitDict();
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
        // bookSlotUI.GetComponent<Image>().color = bookColors[bookSlotUI.BookDetail.bookType];
        Sprite targetSprite = ReadSprite(bookDetail.bookType);
        bookSlotUI.GetComponent<Image>().sprite = targetSprite;
        return bookSlotUI;
    }

    /// <summary>
    /// 根据BookDetail以及世界坐标显示BookTip, 最后一个参数控制开关
    /// </summary>
    /// <param name="bookDetail"></param>
    /// <param name="pos"></param>
    /// <param name="show"></param>
    public void ShowBookTipUIAndFollowSlotUI(BookDetail bookDetail, Transform parent, bool show){
        if(show == false){
            bookTipUI.gameObject.SetActive(false);
            return;
        }

        if(bookDetail==null) return;

        bookTipUI.SetupBookTip(bookDetail);


        bookTipUI.SetFollow(parent, new Vector2(40,-50));
        bookTipUI.gameObject.SetActive(true);

        // bookTipUI.GetComponent<RectTransform>().
        //     position = (Vector2)parent.position + offsetPos;


        StartCoroutine(bookTipUI.Dissolve(0.4f));
    }

    public void InitDict()
    {
        //初始化字典
        bookTypeToSpritePathDict[BookType.Literacy] = "进货商店/书图标/while-";
        bookTypeToSpritePathDict[BookType.Children] = "进货商店/书图标/blue-大海";
        bookTypeToSpritePathDict[BookType.Photography] = "进货商店/书图标/red-";
        bookTypeToSpritePathDict[BookType.Science] = "进货商店/书图标/yellow-";
    }

    public Sprite ReadSprite(BookType bookType)
    {
        string assetPath = BookTypeToSpritePathDict[bookType];
        Sprite targetSprite = Resources.Load<Sprite>(assetPath);
        return targetSprite;
    }
}
