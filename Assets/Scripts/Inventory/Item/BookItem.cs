using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 书本实例的组件
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BookItem : MonoBehaviour
{

    [SerializeField] private Button openInfoButton;

    [SerializeField] private float offsetY;


    private BookDetail bookDetail;
    private bool isSelected;

    public void Init(BookDetail bookDetail){
        this.bookDetail = bookDetail;
    }

    public void OnClicked(){
        if(!isSelected){
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y + offsetY);
            transform.DOMove(newPos, 0.5f);

            openInfoButton.gameObject.SetActive(true);
        }
        else{
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y - offsetY);
            transform.DOMove(newPos, 0.5f);

            openInfoButton.gameObject.SetActive(false);
        }

        isSelected = !isSelected;
    }

    public void OpenBookInfoUI(){
        Debug.Log("UI Open");
        EventHandler.CallOpenBookTipOverlayScreenUI(bookDetail, true);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y + offsetY), 0.1f);
    }
}
