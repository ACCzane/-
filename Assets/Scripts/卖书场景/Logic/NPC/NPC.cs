using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BookSelling
{
    public class NPC : MonoBehaviour
    {
        [Header("引用")]
        [SerializeField] private GameObject UIPanel;
        [SerializeField] private TMP_Text textMeshPro;
        [SerializeField] private Button rejectButton;
        [SerializeField] private Button acceptButton;

        [Header("参数")]
        [SerializeField] private float waitTime;
        private float timer;
        private NPCRequest npcRequest;
        private Vector2 startPos;
        private Vector2 endPos;
        private float npcWalkSpeed;
        private Vector3 UIPanelScale_Small;
        private Vector3 UIPanelScale_normal;

        enum state{
            WalkIn,
            Wait,
            WalkOut
        }

        //好感度-时间函数
        private float[] levels = new float[] {0.6f, 0.8f, 1f};

        private state currentState;

        private BookDetail targetBook;

        private void OnEnable() {
            EventHandler.OpenAcceptButton += OnOpenAcceptButton;
            EventHandler.ClickAcceptButton += OnClickAcceptButton;
        }

        private void OnDisable(){
            EventHandler.OpenAcceptButton -= OnOpenAcceptButton;
            EventHandler.ClickAcceptButton -= OnClickAcceptButton;
        }

        private void Start() {
            UIPanelScale_normal = UIPanel.transform.localScale;
            UIPanelScale_Small = UIPanel.transform.localScale * 0.6f;
        }

        private void Update() {
            if(currentState == state.Wait){
                timer += Time.deltaTime;
                EventHandler.CallNPCWaitTimeUpdate(timer/waitTime);
                if(timer > waitTime){
                    currentState = state.WalkOut;
                    //reset
                    EventHandler.CallNPCWaitTimeUpdate(0);
                    WalkOutFrom();
                }
            }
            if(currentState == state.WalkOut){
                
            }
        }

        public void Init(NPCRequest npcRequest, Vector2 startPos, Vector2 endPos, float npcWalkSpeed){
            this.npcRequest = npcRequest;
            this.startPos = startPos;
            this.endPos = endPos;
            this.npcWalkSpeed = npcWalkSpeed;
        }

        private void AccpetBook(){
            //npc
            WalkOutFrom();

            //场景物品变更
            EventHandler.CallClickAcceptButton(targetBook);
            //玩家得到金币

            //npc获得好感度？
        }

        public void RejectBook(){
            WalkOutFrom();
        }

        public void WalkToPos(){
            currentState = state.WalkIn;
            transform.DOMove(endPos, npcWalkSpeed).OnComplete(OpenUI);
        }
        
        public void WalkOutFrom(){
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            currentState = state.WalkOut;
            CloseText();
            transform.DOMove(startPos, npcWalkSpeed).OnComplete(DestorySelf);

            rejectButton.gameObject.SetActive(false);
            acceptButton.gameObject.SetActive(false);
        }

        private void OpenUI(){
            currentState = state.Wait;
            timer = 0;

            
            UIPanel.SetActive(true);
            UIPanel.transform.DOPunchScale(UIPanelScale_Small,0.5f,10,1f).OnComplete(() => StartCoroutine(SetText(textMeshPro, npcRequest.requestText)));

            // textMeshPro.text = npcRequest.requestText;

            acceptButton.gameObject.SetActive(false);
            rejectButton.gameObject.SetActive(true);
        }

        private IEnumerator SetText(TMP_Text textContainer, string targetText){
            textContainer.text = "";

            for(int i = 0; i < targetText.Count(); i++){
                textContainer.text += targetText[i];

                if(Input.GetMouseButton(0)){
                    textContainer.text = targetText;
                    yield break;
                }

                yield return new WaitForSeconds(0.1f);
            }
        }

        private void DestorySelf(){
            EventHandler.CallNPCRemove();
            Destroy(gameObject);
        }

        private void CloseText(){
            textMeshPro.text = "";
            UIPanel.SetActive(false);
        }


        public void OnOpenAcceptButton(BookDetail book, bool isOpen){

            if(isOpen){
                targetBook = book;
                acceptButton.gameObject.SetActive(true);

                acceptButton.onClick.AddListener(AccpetBook);
            }
            else{
                acceptButton.gameObject.SetActive(false);
            }

            Debug.Log(targetBook.bookName);
        }

        private void OnClickAcceptButton(BookDetail bookDetail)
        {
            //npcFavorability : 0代表愤怒，1代表正常，2以上代表高兴
            int npcFavorability = 0;
            int elfCoin = 0;

            int gainedMoney = 0;

            //等待时间因素
            float waitTimeRatio = timer/waitTime;
            if(waitTimeRatio < levels[0]){
                //笑脸，加好感度
                npcFavorability++;
            }else{
                //烦躁脸，不加好感度
            }
            
            //书本匹配度因素
            if(npcRequest.requestType == RequestType.ByType){
                //如果npc只要求了要某种类型的书
                if(bookDetail.bookType == npcRequest.bookType){
                    //匹配
                    npcFavorability++;
                    elfCoin++;
                }
            }else{
                //如果npc指定了书名，或者有描述（内心有预期）
                foreach (var name in npcRequest.bookName)
                {
                    if(bookDetail.bookName == name){
                        //匹配
                        npcFavorability++;
                        elfCoin++;
                    }
                }
            }

            gainedMoney += (int)(bookDetail.price * bookDetail.sellRatio);

            
            Debug.Log("玩家获得" + gainedMoney + "钱， " + elfCoin + "精灵币， 获得" + npcFavorability + "好感度");
            EventHandler.CallTrade(gainedMoney, elfCoin, npcFavorability);
        }
    }

}
