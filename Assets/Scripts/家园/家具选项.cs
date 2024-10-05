using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class 家具选项 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public Furniture_SO furnitureDatabase;
    public string id;
    Vector3 origin;
    public void OnBeginDrag(PointerEventData eventData)
    {
        origin = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = origin;
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
