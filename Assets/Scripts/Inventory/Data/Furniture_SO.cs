using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "New Furniture_SO", menuName = "Data/Furniture_SO")]
public class Furniture_SO : ScriptableObject
{


    public SerializedDictionary<string, FurnitureDetail> furnitureDict;

    public FurnitureDetail GetById(string id)
    {
        return furnitureDict[id];
    }

    


    [Button]
    void 自动添加(){

    }
}

