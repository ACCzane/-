using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("引用")]
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Rigidbody2D rb;

    [Header("参数")]
    [SerializeField] private float moveSpeed;


    private Vector2 previousInputDir;

    private void OnEnable(){
        inputReader.MoveEvent += HandleMove;
    }

    private void OnDisable(){
        inputReader.MoveEvent -= HandleMove;
    }

    private void HandleMove(Vector2 inputDir)
    {
        previousInputDir = inputDir;
        Debug.Log(previousInputDir);
    }

    private void FixedUpdate() {
        rb.velocity = previousInputDir*moveSpeed;
    }

    private void Update(){
        
    }
}
