using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using PrimeTween;
public class 手动翻页 : MonoBehaviour
{
    public Transform Content;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float value;
    public void Run()
    {
        Tween.PositionX(Content, Content.transform.position.x + value, 0.5f);
    }
}
