using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Baracuda.Monitoring;
using NaughtyAttributes;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class 家具仓库 : MonoBehaviour
{
    public Furniture_SO database;

    public GameObject optionPrefab;
    public Transform Content;
    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }


    void OnEnable()
    {
        ObjectsManager.仓库更新 += Refresh;
    }

    private void OnDisable() {
        ObjectsManager.仓库更新 -= Refresh;
    }

    // Update is called once per frame
    void Update()
    {

    }

    [Button("刷新")]
    public void Refresh()
    {
        BroadcastMessage("Destroy",SendMessageOptions.DontRequireReceiver);
        foreach ((string id, int count) in GameData.GameSave.furnitures)
        {
            var go = Instantiate(optionPrefab, Content);
            go.name = id + " x" + count;
            go.GetComponent<家具选项>().Init(id, count);
        }

    }

    [Button("随机添加一件家具")]
    void test()
    {
        GameData.GameSave.furnitures.Add((database.furnitureDict.Keys.ToArray()[Random.Range(0, database.furnitureDict.Count)], Random.Range(1, 10)));
    }
}
