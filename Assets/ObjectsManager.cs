using System;
using System.Collections;
using System.Collections.Generic;
using Baracuda.Monitoring;
using UnityEngine;

public class ObjectsManager : MonitoredBehaviour
{
    [MonitorEvent]
    public static event Action 仓库更新;
    public Furniture_SO furnitureDatabase;
    public RectTransform 底部按钮;
    void Start()
    {
        Refresh();
    }

    void Refresh()
    {
        foreach (PlacedFurniture i in GameData.GameSave.placedFurnitures)
        {
            PlaceFurniture(i);
        }
    }

    void Update()
    {

    }

    void UI_Update(家园对象 obj)
    {
        //底部按钮.position = obj.transform.position;

        //底部按钮 is canvas object, so it's position is not in world space
        底部按钮.position = Camera.main.WorldToScreenPoint(obj.transform.position);
        底部按钮.gameObject.SetActive(true);
    }

    //退回到仓库
    public void 按下取消(bool OnlyDelete)
    {
        Destroy(家园对象.selected.gameObject);
        GameData.GameSave.RevertToStorage(家园对象.selected.placedFurniture);

        按下确认();
    }

    //隐藏ui
    public void 按下确认()
    {
        底部按钮.gameObject.SetActive(false);

        仓库更新.Invoke();
    }


    public void 按下旋转()
    {
        家园对象.selected.placedFurniture.status++;
    }

    public void PlaceFurniture(PlacedFurniture placedFurniture)
    {
        FurnitureDetail furnitureDetail = furnitureDatabase.GetById(placedFurniture.id);
        var furniture = Instantiate(furnitureDetail.prefab[placedFurniture.status % furnitureDetail.prefab.Length], placedFurniture.position, Quaternion.identity, transform);
        furniture.GetComponent<家园对象>().Init(placedFurniture);
    }
}
