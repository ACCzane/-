using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BookSelling
{
    public class NPCSpawner : MonoBehaviour
    {
        [Header("引用")]
        [SerializeField] private GameObject npcPrefab;
        [Header("参数")]
        [SerializeField] private Vector2 startPos;
        [SerializeField] private Vector2 endPos;
        [SerializeField] private float npcWalkSpeed;

        private void OnEnable() {
            EventHandler.NPCRequestForBook += OnNPCRequestForBook;
        }

        private void OnDisable() {
            EventHandler.NPCRequestForBook -= OnNPCRequestForBook;
        }

        private void OnNPCRequestForBook(NPCRequest request)
        {
            // npcGO
            GameObject npcGO = Instantiate(npcPrefab, startPos, Quaternion.identity);
            NPC npc = npcGO.GetComponent<NPC>();
            npc.Init(request);
            npc.WalkToPos(endPos);
        }

        private void OnDrawGizmosSelected() {
            Gizmos.DrawWireSphere(startPos, 1f);
            Gizmos.DrawWireSphere(endPos, 1f);
        }
    }
}
