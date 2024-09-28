using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookStorageUI : MonoBehaviour
{
    [SerializeField] private BookStorage_SO bookStorage_SO;

    [SerializeField] private TextMeshProUGUI bookAmount1;
    [SerializeField] private TextMeshProUGUI bookAmount2;
    [SerializeField] private TextMeshProUGUI bookAmount3;
    [SerializeField] private TextMeshProUGUI bookAmount4;
    [SerializeField] private TextMeshProUGUI bookAmount5;

    private void OnEnable() {
        EventHandler.UpdateStorageUI += UpdateBookStorageUI;
    }

    private void OnDisable() {
        EventHandler.UpdateStorageUI -= UpdateBookStorageUI;
    }

    private void Start() {
        UpdateBookStorageUI();
    }

    private void UpdateBookStorageUI()
    {
        bookAmount1.text = bookStorage_SO.books_children.Count.ToString();
        bookAmount2.text = bookStorage_SO.books_literacy.Count.ToString();
        bookAmount3.text = bookStorage_SO.books_Love.Count.ToString();
        bookAmount4.text = bookStorage_SO.books_Photography.Count.ToString();
        bookAmount5.text = bookStorage_SO.books_Science.Count.ToString();
    }
}
