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
        ItemUIManager.Singleton.ShowBookTipUIAndFollowSlotUI(bookSlotUI.BookDetail, transform, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemUIManager.Singleton.ShowBookTipUIAndFollowSlotUI(null, null, false);
    }
}
