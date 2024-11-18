using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BookSelling
{
public class BookSpawner : MonoBehaviour
    {
        [Header("引用")]
        [SerializeField] private GameObject bookPrefab;
        [SerializeField] private BooksBagUI booksBagUI;
        [SerializeField] private BookTipUI bookTipUI;
        [Header("参数")]
        [SerializeField] private Vector2 startLocalPos;
        private Vector2 startPos => startLocalPos + new Vector2(transform.position.x, transform.position.y);
        private List<BookDetail> books;
        private List<BookItem> bookItems = new List<BookItem>();

        private void OnEnable() {
            EventHandler.LinkBooksToNPC += OnLinkBooksToNPC;
            EventHandler.ClickAcceptButton += OnClickAcceptButton;
        }

        private void OnDisable() {
            EventHandler.LinkBooksToNPC -= OnLinkBooksToNPC;
            EventHandler.ClickAcceptButton -= OnClickAcceptButton;
        }


        public void SpawnBooks(List<BookDetail> books){
            this.books = books;
            Debug.Log(books.Count);
            foreach (var item in bookItems)
            {
                //BookItem的子物体有UI、可能有BookTip，为了避免BookTip被不小心随物体删除，要解除它们的父子关系绑定
                if(item.transform.childCount == 2){
                    item.transform.GetChild(1).SetParent(null);
                }
                Destroy(item.gameObject);
            }
            bookItems.Clear();


            Vector2 newPos = new Vector2(startPos.x, startPos.y);
            for(int i = 0; i < books.Count; i++){
                Debug.Log(newPos);

                BookItem bookItem = Instantiate(bookPrefab, newPos, Quaternion.identity).GetComponent<BookItem>();

                //初始化bookGO
                bookItem.Init(books[i], bookTipUI);

                bookItems.Add(bookItem);

                //newPos.x自增
                newPos.x += bookItem.ColliderSize.x;

            }
        }

        public void OnLinkBooksToNPC(NPC npc){
            if(npc == null){
                Debug.LogError("No valid NPC!");
                return;
            }
            if(bookItems == null){
                Debug.LogError("UnInitialized List<BookItme>!");
                return;
            }
            for(int i = 0; i < bookItems.Count; i++){
                bookItems[i].SetTargetNPC(npc); 
            }
        }

        public void OnClickAcceptButton(BookDetail bookDetail){
            Debug.Log(books.Count);
            //重置书架上的书，更新数据
            foreach(var book in books){
                if(book == bookDetail){
                    Debug.Log(book);
                    books.Remove(book);
                    
                    break;
                }
            }
            Debug.Log(books.Count);
            SpawnBooks(books);
        }

        private void UpdateBooks(){
            foreach (BookItem bookItem in bookItems)
            {
                if(bookItem.IsSelected){
                    books.Remove(bookItem.BookDetail);
                    break;
                }
            }
            SpawnBooks(books);
        }


        private void OnDrawGizmosSelected() {
            Gizmos.DrawWireSphere(startPos, 0.1f);
        }

        public void OpenBooksBagUI()
        {
            // booksBagUI = GameObject.Find("BookBagUI").GetComponent<BooksBagUI>();
            if(booksBagUI.CanOpen)
                booksBagUI.EnterUI(this);
        }
    }

}
