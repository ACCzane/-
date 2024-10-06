using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPCRequests", menuName = "NPC/NPCRequest")]
public class NPCRequest_SO : ScriptableObject
{
    public List<NPCRequest> normalNPCRequests = new List<NPCRequest>();
    public List<NPCRequest> specialNPCRequests = new List<NPCRequest>();
}
