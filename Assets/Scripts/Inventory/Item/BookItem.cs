using System.Collections;
using System.Collections.Generic;
using BookSelling;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 书本实例的组件
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BookItem : MonoBehaviour, IImageLoader
{

    [SerializeField] private Button openInfoButton;
    [SerializeField] private BookTipUI bookTipUI;
    [SerializeField] private float offsetY;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    public BookDetail BookDetail{get; private set;}
    public bool IsSelected{get; private set;} = false;

    private Dictionary<BookType, string> bookTypeToSpritePathDict = new Dictionary<BookType, string>();
    public Dictionary<BookType, string> BookTypeToSpritePathDict => bookTypeToSpritePathDict;

    private bool isTipShow = false;
    private bool canClick = true;

    private NPC targetNPC;

    private void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        InitDict();
    }

    private void OnEnable() {
        EventHandler.UnSelectOtherBooks += UnSelectSelf;
    }

    private void OnDisable() {
        EventHandler.UnSelectOtherBooks -= UnSelectSelf;
    }

    public void Init(BookDetail bookDetail, BookTipUI bookTipUI){
        this.BookDetail = bookDetail;
        this.bookTipUI = bookTipUI;

        spriteRenderer.sprite = ReadSprite(bookDetail.bookType);
        InitColliderBound(spriteRenderer.sprite);
    }

    public void SetTargetNPC(NPC npc){
        targetNPC = npc;
    }

    public void OnClicked(){
        if(!canClick){return;}

        if(!IsSelected){
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y + offsetY);
            canClick = false;
            transform.DOMove(newPos, 0.2f).OnComplete(()=>canClick = true);
            rigidbody2D.gravityScale = 0;

            openInfoButton.gameObject.SetActive(true);

            EventHandler.CallOpenAcceptButton(BookDetail, true);

            EventHandler.CallUnSelectOtherBooks(this);
        }
        else{
            rigidbody2D.gravityScale = 1;
            openInfoButton.gameObject.SetActive(false);

            EventHandler.CallOpenAcceptButton(null, false);
        }

        IsSelected = !IsSelected;
    }

    public void UnSelectSelf(BookItem bookItem){
        if(bookItem == this){return;}

        if(IsSelected){
            rigidbody2D.gravityScale = 1;
            openInfoButton.gameObject.SetActive(false);
        }
        IsSelected = false;
    }

    public void OpenBookInfoUI(){
        // EventHandler.CallOpenBookTipOverlayScreenUI(bookDetail, true);
        isTipShow = !isTipShow;
        ShowBookTipUIAndFollowBook(BookDetail, transform, isTipShow);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y + offsetY), 0.1f);
    }

    public void ShowBookTipUIAndFollowBook(BookDetail bookDetail, Transform parent, bool show){
        if(show == false){
            bookTipUI.gameObject.SetActive(false);
            return;
        }

        if(bookDetail==null) return;

        bookTipUI.SetupBookTip(bookDetail);


        bookTipUI.transform.SetParent(parent);
        bookTipUI.gameObject.SetActive(true);

        Vector2 offsetPos = new Vector2(0,0);
        bookTipUI.GetComponent<RectTransform>().
            position = (Vector2)parent.position + offsetPos;


        StartCoroutine(bookTipUI.Dissolve(0.4f));
    }

    private void InitColliderBound(Sprite bookSprite){
        boxCollider2D.size = new Vector2(
            (bookSprite.rect.width-bookSprite.border.x-bookSprite.border.z) / bookSprite.pixelsPerUnit, 
            (bookSprite.rect.height-bookSprite.border.y-bookSprite.border.w) / bookSprite.pixelsPerUnit
        );
        boxCollider2D.offset = new Vector2(
            (bookSprite.border.x - bookSprite.border.z) / (2*bookSprite.pixelsPerUnit),
            (bookSprite.border.y - bookSprite.border.w) / (2*bookSprite.pixelsPerUnit)
        );
    }

    public void InitDict()
    {
        //初始化字典
        bookTypeToSpritePathDict[BookType.Literacy] = "售卖/售卖/book-白色1";
        bookTypeToSpritePathDict[BookType.Children] = "售卖/售卖/book-蓝色1";
        bookTypeToSpritePathDict[BookType.Love] = "售卖/售卖/book-黄色1";
        bookTypeToSpritePathDict[BookType.Photography] = "售卖/售卖/book-黄色2";
        bookTypeToSpritePathDict[BookType.Science] = "售卖/售卖/book-黄色2";
    }

    public Sprite ReadSprite(BookType bookType)
    {
        string assetPath = BookTypeToSpritePathDict[bookType];
        Sprite targetSprite = Resources.Load<Sprite>(assetPath);
        return targetSprite;
    }
}
