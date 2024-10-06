using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BookSlotUI))]
public class ShowBookTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private BookSlotUI bookSlotUI;

    private void OnEnable() {
        bookSlotUI = GetComponent<BookSlotUI>();    
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ItemUIManager.Singleton.ShowBookTipUIAtWorldPos(bookSlotUI.BookDetail, transform.position, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemUIManager.Singleton.ShowBookTipUIAtWorldPos(null, Vector2.zero, false);
    }
}
