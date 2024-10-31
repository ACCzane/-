
using UnityEngine;
using UnityEngine.EventSystems;
using NaughtyAttributes;
using PrimeTween;
public class 家具仓库按钮 : MonoBehaviour ,IPointerClickHandler
{

    public 家园相机逻辑 logic;
    public void OnPointerClick(PointerEventData eventData)
    {
        logic.切换到家具仓库();   
        
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
