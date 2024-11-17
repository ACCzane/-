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
            EventHandler.NPCSpawn += OnNPCSpawn;
        }

        private void OnDisable() {
            EventHandler.NPCSpawn -= OnNPCSpawn;
        }

        private void OnNPCSpawn(NPCRequest request)
        {
            // npcGO
            GameObject npcGO = Instantiate(npcPrefab, startPos, Quaternion.identity);
            NPC npc = npcGO.GetComponent<NPC>();
            npc.Init(request, startPos, endPos, npcWalkSpeed);

            EventHandler.CallLinkBooksToNPC(npc);

            npc.WalkToPos();
        }

        private void OnDrawGizmosSelected() {
            Gizmos.DrawWireSphere(startPos, 1f);
            Gizmos.DrawWireSphere(endPos, 1f);
        }
    }
}
