using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStat : MonoBehaviour
{
    private Animation npcStatAnim;

    private void Awake() {
        npcStatAnim = GetComponent<Animation>();
    }

    public void PlayAnim(NPCMood nPCMood){
        if(nPCMood == NPCMood.happy){
            npcStatAnim.Play("npcHappy");
        }
        if(nPCMood == NPCMood.mad){
            npcStatAnim.Play("npcMad");
        }
    }

    public void HideVisualItem(){
        gameObject.SetActive(false);
    }
}
