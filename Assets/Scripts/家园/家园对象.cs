using System;
using System.Collections;
using System.Collections.Generic;
using Baracuda.Monitoring;
using UnityEngine;
using UnityEngine.EventSystems;

public class 家园对象 : MonitoredBehaviour, IPointerClickHandler
{
    PlacedFurniture placedFurniture;

    [Monitor]
    bool ui_state = false; // 0: normal, 1: selected
    public void OnPointerClick(PointerEventData eventData)
    {
        ui_state = !ui_state;
    }

    internal void Init(string id, Vector3 mousePos)
    {
        placedFurniture.id=id;
        placedFurniture.position=mousePos;
        placedFurniture.status=0;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public struct PlacedFurniture{
    public string id;
    public Vector3 position;
    public int status;
}
