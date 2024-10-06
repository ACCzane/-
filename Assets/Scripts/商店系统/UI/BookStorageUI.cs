using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookStorageUI : MonoBehaviour
{
    private BookStorage bookStorage;

    [SerializeField] private TextMeshProUGUI bookAmount1;
    [SerializeField] private TextMeshProUGUI bookAmount2;
    [SerializeField] private TextMeshProUGUI bookAmount3;
    [SerializeField] private TextMeshProUGUI bookAmount4;
    [SerializeField] private TextMeshProUGUI bookAmount5;

    private void Awake() {
        bookStorage = GameData.GameSave.bookStorage;
    }

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
        bookAmount1.text = "Literacy"+bookStorage.booksInStorage.Where(book => book.bookType == BookType.Literacy).ToList().Count.ToString();
        bookAmount2.text = "Children"+bookStorage.booksInStorage.Where(book => book.bookType == BookType.Children).ToList().Count.ToString();
        bookAmount3.text = "Science"+bookStorage.booksInStorage.Where(book => book.bookType == BookType.Science).ToList().Count.ToString();
        bookAmount4.text = "Love"+bookStorage.booksInStorage.Where(book => book.bookType == BookType.Love).ToList().Count.ToString();
        bookAmount5.text = "Photo"+bookStorage.booksInStorage.Where(book => book.bookType == BookType.Photography).ToList().Count.ToString();
    }
}
