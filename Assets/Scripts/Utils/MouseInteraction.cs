using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BookSelling;

public class MouseInteraction : MonoBehaviour
{
    private void Update()
    {
        // 检测鼠标左键是否按下
        if (Input.GetMouseButtonDown(0)) // 0 表示左键
        {
            // 将鼠标屏幕位置转换为世界坐标
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero); // 使用射线检测

            // 检查是否击中物体
            if (hit.collider != null)
            {
                //如果击中书架
                if(hit.collider.TryGetComponent<BookSpawner>(out BookSpawner bookSpawner)){
                    bookSpawner.OpenBooksBagUI();
                }
                //如果击中书籍
                if(hit.collider.TryGetComponent<BookItem>(out BookItem bookItem)){
                    bookItem.OnClicked();
                }
            }
        }
    }
}
