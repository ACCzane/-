using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookTipUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI typeText;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private TextMeshProUGUI valueText;

    public void SetupBookTip(BookDetail bookDetail){
        nameText.text = bookDetail.bookName;
        typeText.text = bookDetail.bookType.ToString();
        infoText.text = bookDetail.bookIntro;
        valueText.text = bookDetail.price.ToString();
    }
}
