using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SaveSystemEditor
{
    [MenuItem("存档/在文件资源管理器中显示", false, 100)]
    public static void OpenFolder()
    {
        EditorUtility.RevealInFinder(GameData.file);
    }
    [MenuItem("存档/打开GameData.json", false, 100)]
    public static void OpenFile()
    {
        EditorUtility.OpenWithDefaultApp(GameData.file);
    }
    [MenuItem("存档/删除GameData.json（模拟首次启动）", false, 100)]
    public static void Clear()
    {
        GameData.Clear();
    }



    [MenuItem("存档/保存",false,1000)]
    public static void Save()
    {
        GameData.Save();
    }

    [MenuItem("存档/修改下次保存的槽位", false, 1000)]
    public static void ChangeIndex()
    {
        EditorWindow.GetWindow<QuickNumberInput>().Show();

    }
    public class QuickNumberInput : EditorWindow
    {
        int tmp;
        private void OnGUI()
        {
            GUILayout.Label("修改存档槽位");
            GUILayout.Label("当前槽位" + GameData.index);
            GameData.index = EditorGUILayout.IntField("槽位",  GameData.index);
            GUILayout.Label("0~9共10个存档槽位");
        }
    }


    public static void 随机加入家具()
    {
        
        for (int i = 0; i < 10; i++)
        {
            
        }
    }
}