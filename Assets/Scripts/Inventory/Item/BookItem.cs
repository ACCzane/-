using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 书本实例的组件
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BookItem : MonoBehaviour
{
    public int bookId;

    // 预计只有UI
    // private Collider2D coll;
    // private SpriteRenderer spriteRenderer;

    // private void Awake() {
    //     coll = GetComponent<Collider2D>();
    //     spriteRenderer = GetComponent<SpriteRenderer>();
    // }
}
