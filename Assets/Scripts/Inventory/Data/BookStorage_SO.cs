using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BookStorage", menuName = "Bag/BookStorage")]
public class BookStorage_SO : ScriptableObject
{
    // public int defaultCapacity = 5;
    public List<BookDetail> books;
}
