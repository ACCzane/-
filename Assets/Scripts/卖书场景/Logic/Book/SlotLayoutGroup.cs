using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BookSelling
{
    public class SlotLayoutGroup : MonoBehaviour
    {
        private BoxCollider2D boxCollider2D;
        [SerializeField] private GameObject bookPrefab;

        private float bookWidth;
        private float bookHeight;
        private float containerWidth;

        private void Awake() {
            boxCollider2D = GetComponent<BoxCollider2D>();
        }

        public void Init(){
            bookWidth = bookPrefab.GetComponent<BoxCollider>().size.x;
            bookHeight = bookPrefab.GetComponent<BoxCollider>().size.y;
            containerWidth = boxCollider2D.size.x;
        }

        private void OnMouseDown() {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 pos = new Vector3(mousePosition.x, mousePosition.y, 0);

            SpawnBook(pos);
        }

        private void SpawnBook(Vector3 pos){
            GameObject bookGO = Instantiate(bookPrefab, transform);
            bookGO.transform.position = pos;
        }
    }
}

