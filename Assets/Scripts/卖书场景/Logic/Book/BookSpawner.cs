using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BookSelling
{
public class BookSpawner : MonoBehaviour
    {
        [Header("引用")]
        [SerializeField] private GameObject bookPrefab;
        [SerializeField] private BooksBagUI booksBagUI;
        [Header("参数")]
        [SerializeField] private float gap;
        [SerializeField] private Vector2 startLocalPos;
        private Vector2 startPos => startLocalPos + new Vector2(transform.position.x, transform.position.y);
        private List<BookDetail> books;
        private List<BookItem> bookItems = new List<BookItem>();

        public void SpawnBooks(List<BookDetail> books){
            this.books = books;
            foreach (var item in bookItems)
            {
                Destroy(item);
            }
            bookItems.Clear();

            for(int i = 0; i < books.Count; i++){
                Vector2 pos = new Vector2(startPos.x + gap * i, startPos.y);
                BookItem bookItem = Instantiate(bookPrefab, pos, Quaternion.identity).GetComponent<BookItem>();

                //初始化bookGO
                bookItem.Init(books[i]);

                bookItems.Add(bookItem);
            }
        }

        private void OnDrawGizmosSelected() {
            Gizmos.DrawWireSphere(startPos, 0.1f);
            Gizmos.DrawWireSphere(new Vector2(startPos.x + gap, startPos.y), 0.1f);
        }

        public void OpenBooksBagUI()
        {
            // booksBagUI = GameObject.Find("BookBagUI").GetComponent<BooksBagUI>();

            booksBagUI.EnterUI(this);
        }
    }

}
