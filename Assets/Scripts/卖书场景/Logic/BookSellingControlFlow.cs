using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BookSelling
{
    public class BookSellingControlFlow : MonoBehaviour
    {
        [Header("参数")]
        [SerializeField] private int speed = 2;

        [Header("引用")]
        [SerializeField] private NPCRequest_SO npcRequest_SO;
        [SerializeField] private Button quitButton;
        [SerializeField] private Button startButton;

        private bool hasNPC;

        private PlayerAsset playerAsset;


        private void OnEnable() {
            EventHandler.NPCRemove += OnNPCRemove;
            EventHandler.Trade += OnTrade;
        }   

        private void OnDisable() {
            EventHandler.NPCRemove -= OnNPCRemove;
            EventHandler.Trade -= OnTrade;
        }

        private void Start() {
            playerAsset = GameData.GameSave.playerAsset;

            EventHandler.CallUpdatePlayerMoney(playerAsset.money);
            EventHandler.CallPlayerLikesChanged(playerAsset.likes);
            EventHandler.CallUpdateTimeUI(8, 0);

            quitButton.onClick.AddListener(QuitScene);
            startButton.onClick.AddListener(StartSellBook);
        }

        private void Update() {
            //TODO:随机时间来客
            if(TimeManager.Singleton.hour == 8 && TimeManager.Singleton.minute == 30 && !hasNPC){
                NPCBuyBook();
                hasNPC = true;
            }

            if(TimeManager.Singleton.hour == 10 && TimeManager.Singleton.minute == 30 && !hasNPC){
                NPCBuyBook();
                hasNPC = true;
            }

            if(TimeManager.Singleton.hour == 12 && TimeManager.Singleton.minute == 30 && !hasNPC){
                NPCBuyBook();
                hasNPC = true;
            }
        }

        public void StartSellBook(){
            StartCoroutine(TimeManager.Singleton.StartNewPeriord(8,19,speed));
            startButton.gameObject.SetActive(false);
        }

        public void NPCBuyBook(){
            //TODO:目前实现的是随机抽取NPCRequestSO中List<NPCRequest>的元素，后续等策划更新规则
            if(npcRequest_SO.normalNPCRequests == null){return;}
            int randomIndex = Random.Range(0, npcRequest_SO.normalNPCRequests.Count);
            NPCRequest npcRequest = npcRequest_SO.normalNPCRequests[randomIndex];

            EventHandler.CallNPCSpawn(npcRequest);
        }


        private void OnNPCRemove()
        {
            hasNPC = false;
        }

        private void OnTrade(int gainedMoney, int elfCoin, int npcFavorability)
        {
            playerAsset.money += gainedMoney;
            playerAsset.likes += npcFavorability;
            EventHandler.CallUpdatePlayerMoney(playerAsset.money);
            EventHandler.CallPlayerLikesChanged(playerAsset.likes);
        }

        public void QuitScene(){
            SceneLoadManager.Singleton.LoadScene("大厅");
        }

    }

}
