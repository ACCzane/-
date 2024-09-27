using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemBag", menuName = "Bag/ItemBag")]
public class ItemBag_SO : ScriptableObject
{
    public List<ItemDetail> items;
}
