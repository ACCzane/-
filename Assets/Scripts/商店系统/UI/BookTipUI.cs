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



    [SerializeField] private Material material;
    private static int dissolveValue = Shader.PropertyToID("_DissolveAmount");


    public void SetupBookTip(BookDetail bookDetail){
        nameText.text = bookDetail.bookName;
        typeText.text = bookDetail.bookType.ToString();
        infoText.text = bookDetail.bookIntro;
        valueText.text = bookDetail.price.ToString();
    }

    public IEnumerator Dissolve(float duration){
        float elapsedTime = 0;
        float lerpedAmount = 0;
        while(elapsedTime < duration){
            elapsedTime += Time.deltaTime;
            lerpedAmount = Mathf.Lerp(0, 1, elapsedTime/duration);

            material.SetFloat(dissolveValue, 1-lerpedAmount);
            yield return null;
        }
    }
}
