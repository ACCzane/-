using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace BookSelling
{
    public class NPC : MonoBehaviour
    {
        [Header("引用")]
        [SerializeField] private GameObject UIPanel;
        [SerializeField] private TMP_Text textMeshPro;
        [Header("参数")]
        [SerializeField] private float waitTime;
        private float timer;
        private NPCRequest npcRequest;

        enum state{
            WalkIn,
            Wait,
            WalkOut
        }

        private state currentState;

        private void Update() {
            if(currentState == state.Wait){
                timer += Time.deltaTime;
                if(timer > waitTime){
                    currentState = state.WalkOut;
                }
            }
            if(currentState == state.WalkOut){

            }
        }

        public void Init(NPCRequest npcRequest){
            this.npcRequest = npcRequest;
        }

        public void WalkToPos(Vector2 pos){
            currentState = state.WalkIn;
            transform.DOMove(pos, 2).OnComplete(OpenText);
        }
        
        public void WalkOutFrom(Vector2 pos){
            transform.DOMove(pos, 2);
        }

        private void OpenText(){
            currentState = state.Wait;
            timer = 0;

            UIPanel.SetActive(true);
            textMeshPro.text = npcRequest.requestText;
        }
    }

}
