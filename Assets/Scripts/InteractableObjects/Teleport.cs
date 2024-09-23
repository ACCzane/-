using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : InteractableObjectBase
{
    [Header("参数")]
    [SerializeField] private string targetSceneName;

    protected override void OnMouseDown(){
        base.OnMouseDown();

        SceneManager.LoadScene(targetSceneName, LoadSceneMode.Single);
    }
}
