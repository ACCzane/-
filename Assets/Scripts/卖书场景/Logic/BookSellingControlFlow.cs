using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BookSelling
{
    public class BookSellingControlFlow : MonoBehaviour
    {
        [Header("参数")]
        [SerializeField] private int speed = 2;

        [Header("引用")]
        [SerializeField] private NPCRequest_SO npcRequest_SO;

        private bool hasNPC;

        private void Update() {
            //TODO:随机时间来客
            if(TimeManager.Singleton.hour == 8 && !hasNPC){
                NPCBuyBook();
                hasNPC = true;
            }
        }

        public void StartSellBook(){
            StartCoroutine(TimeManager.Singleton.StartNewPeriord(8,19,speed));
        }

        public void NPCBuyBook(){
            //TODO:目前实现的是随机抽取NPCRequestSO中List<NPCRequest>的元素，后续等策划更新规则
            if(npcRequest_SO.normalNPCRequests == null){return;}
            int randomIndex = Random.Range(0, npcRequest_SO.normalNPCRequests.Count);
            NPCRequest npcRequest = npcRequest_SO.normalNPCRequests[randomIndex];

            EventHandler.CallNPCRequestForBook(npcRequest);
        }
    }

}
