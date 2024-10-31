using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Cinemachine;
public class 家园相机逻辑 : MonoBehaviour
{
    //get cinemachine virtual camera
    public CinemachineVirtualCamera 固定;
    public CinemachineVirtualCamera 家具仓库;

    public Transform 家具仓库画布;
    public Transform 主界面画布;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Button]
    public void 切换到家具仓库(){
        固定.Priority = 0;
        家具仓库.Priority = 1;

        //弹出家具仓库画布
        家具仓库画布.gameObject.SetActive(true);
        主界面画布.gameObject.SetActive(false);
    }


    [Button]
    public void 切换到固定(){
        固定.Priority = 1;
        家具仓库.Priority = 0;

        //关闭家具仓库画布
        家具仓库画布.gameObject.SetActive(false);
        主界面画布.gameObject.SetActive(true);
    }
}
