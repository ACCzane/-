using System.Collections.Generic;
using System.Linq;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 家具选项 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public Furniture_SO furnitureDatabase;
    public string id;
    public int number;
    Vector3 origin;
    public Image image;
    public TextMeshProUGUI text;

    public RectTransform 物体底部按钮;

    public ObjectsManager objectManager;
    public void OnBeginDrag(PointerEventData eventData)
    {
        origin = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

        //use event system to detect if the mouse is over background sprite

    }

    public GameObject background;
    public async void OnEndDrag(PointerEventData eventData)
    {
        //通过event system检测鼠标是否在背景精灵上
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);

        if (raycastResults.Any(res => res.gameObject == background))
        {
            transform.position = origin;

            //mouse position to world position
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;


            PlacedFurniture placedFurniture = GameData.GameSave.Transfer(id, mousePos);

            objectManager.PlaceFurniture(placedFurniture);
        }
        else
        {
            await Tween.Position(transform, origin, 0.2f);
            
        }



        GetComponentInParent<家具仓库>().Refresh();
    }
    public void Init(string id, int count)
    {

        this.id = id;
        this.number = count;

        text.SetText(count.ToString());

        image.sprite = furnitureDatabase.GetById(id).sprites[0];
        image.SetNativeSize();
        GetComponent<RectTransform>().sizeDelta = image.GetComponent<RectTransform>().rect.size;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {



        }
    }

    void Destroy()
    {
        DestroyImmediate(gameObject);
    }
}
