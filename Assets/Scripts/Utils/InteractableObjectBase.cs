using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InteractableObjectBase : MonoBehaviour
{
    [Header("引用")]
    [SerializeField] protected SpriteRenderer itemSpriteRenderer;

    [Header("参数")]
    protected Color normalColor;
    [SerializeField] protected Color selectedColor;
    [SerializeField] protected InteractableObjectType interactType;

    protected void Start() {
        normalColor = itemSpriteRenderer.color;
    }

    protected void OnMouseEnter() {
        itemSpriteRenderer.color = selectedColor;
    }

    protected void OnMouseExit() {
        itemSpriteRenderer.color = normalColor;
    }

    protected virtual void OnMouseDown() {
        Debug.Log(gameObject);
    }
}
