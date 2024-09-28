using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class InteractableUIBase : MonoBehaviour
{
    [Header("引用")]
    [SerializeField] private Button button;
}
