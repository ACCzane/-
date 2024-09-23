using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputControl;

/// <summary>
/// 用于读取InputControl.cs的回调，单独抽离的一个类
/// </summary>
[CreateAssetMenu(fileName = "New Input Reader", menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public event Action<Vector2> MoveEvent;

    private InputControl controls;

    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new InputControl();
            controls.Player.SetCallbacks(this);
        }

        controls.Player.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

}

