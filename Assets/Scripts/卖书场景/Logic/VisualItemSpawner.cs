using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualItemSpawner : MonoBehaviour
{
    [SerializeField] private NPCStat nPCStat;

    private void OnEnable() {
        EventHandler.Trade += OnTrade;
    }

    private void OnDisable() {
        EventHandler.Trade -= OnTrade;
    }

    private void OnTrade(int arg1, int arg2, int npcFavorability)
    {
        if(npcFavorability == 0){
            PlayVisualItemAnimByNPCStat(NPCMood.mad);
        }else if(npcFavorability == 2){
            PlayVisualItemAnimByNPCStat(NPCMood.happy);
        }
    }

    public void PlayVisualItemAnimByNPCStat(NPCMood nPCMood){
        nPCStat.gameObject.SetActive(true);
        nPCStat.PlayAnim(nPCMood);
    }
}
