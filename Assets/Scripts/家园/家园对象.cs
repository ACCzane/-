using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Baracuda.Monitoring;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Timeline;

public class 家园对象 : MonitoredBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [Monitor][MValueProcessor(nameof(MonitorPlacedFurniture))]
    public PlacedFurniture placedFurniture;

    string MonitorPlacedFurniture(PlacedFurniture placedFurniture){
        return JsonUtility.ToJson(placedFurniture);
    }
    


    [Monitor]
    public static 家园对象 selected;

    public void OnPointerClick(PointerEventData eventData)
    {
        selected = this;

        SendMessageUpwards("UI_Update", this);
        //我希望在下面有一个objectsManager的引用，方便我在IDE中跳转到ObjectsManager，但是我本身并不希望下面有内容被执行
        var m = typeof(ObjectsManager);

    }


    void OnDestroy()
    {
        if (selected == this)
        {
            selected = null;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;

    }

    Vector3 origin;
    public void OnBeginDrag(PointerEventData eventData)
    {
        origin = transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //修改家具位置
        placedFurniture.position = transform.position;
        
    }

    internal void Init(PlacedFurniture placedFurniture)
    {
        this.placedFurniture = placedFurniture;

    }
}

public class PlacedFurniture
{
    public string id;
    public Vector3 position;  //z==0
    public int status;

    internal void NextStatus()
    {
    }
}
