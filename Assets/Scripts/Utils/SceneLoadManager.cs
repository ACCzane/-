using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{

    public static SceneLoadManager Singleton;

    private void Awake()
    {
        if(Singleton == null){
            Singleton = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    // 异步加载指定场景
    public void LoadScene(string sceneName){

        //保存数据
        GameData.Save();

        SceneManager.LoadSceneAsync(sceneName);
    }
}
