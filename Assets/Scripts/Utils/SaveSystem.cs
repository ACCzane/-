using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>
/// 该组件只是一个调用存档API，并修改存档内容的例子。存档系统本身无需任何组件，正式版中无需此组件。
/// </summary>
[ExecuteAlways]
public class SaveSystem : MonoBehaviour
{
    public GameSave gameSave;
    GUIStyle settings;

    private void OnEnable()
    {
        GameData.OnSaveChanged += OnSaveChanged;
    }

    private void OnSaveChanged()
    {
        gameSave = GameData.GameSave;

    }
    private void Start()
    {
        OnSaveChanged();
    }
    void Update()
    {
        GameData.GameSave = gameSave;
    }


    private void OnGUI()
    {
        
        settings = new GUIStyle(GUI.skin.label){fontSize = 60};
        if (gameSave != null)
        {
            for (int i = 0; i < gameSave.items.Count; i++)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("物品" + i,settings);
                GUILayout.Label("id: " + gameSave.items[i].id,settings);
                GUILayout.Label("lore: " + gameSave.items[i].lore,settings);
                GUILayout.Label("display: " + gameSave.items[i].display,settings);
                GUILayout.EndHorizontal();
            }

        }

    }

    private void OnDisable()
    {
        GameData.OnSaveChanged -= OnSaveChanged;
    }
}


public class GameData
{
    [JsonRequired]
    private GameSave[] gameSaves;

    public static int index;
    public static readonly GameData Current;
    public static Action OnSaveChanged;

    public static GameSave GameSave
    {
        get
        {
            if (Current.gameSaves[index] == null)
            {
                Current.gameSaves[index] = new GameSave();
            }
            return Current.gameSaves[index];
        }
        set
        {
            Current.gameSaves[index] = value;
        }
    }

    public static string file = Path.Combine(Application.persistentDataPath, "GameData.json");
    public static readonly JsonSerializerSettings SerializeSettings = new JsonSerializerSettings
    {
        Formatting = Formatting.Indented,
        // ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        // PreserveReferencesHandling = PreserveReferencesHandling.Objects,
        // TypeNameHandling = TypeNameHandling.Auto,
    };

    public static bool firstBoot;
    static GameData()
    {
        if (File.Exists(file))
        {
            firstBoot = false;
            string json = File.ReadAllText(file);
            Current = JsonConvert.DeserializeObject<GameData>(json, SerializeSettings);


        }
        else
        {
            firstBoot = true;
            Current = new GameData()
            {
                gameSaves = new GameSave[10]
            };
        }

        // OnSaveChanged?.Invoke();

    }
    public static void Save()
    {
        Debug.Log("Saving...");

        string json = JsonConvert.SerializeObject(Current, SerializeSettings);
        File.WriteAllText(file, json);

    }

    public static void Clear()
    {
        File.Delete(file);
    }
}

[System.Serializable]
public class GameSave
{
    public List<Item> items = new();
    public BookStorage bookStorage = new BookStorage();
}

[System.Serializable]
public struct Item
{
    public string id;
    public string lore;
    public bool display;


    //detect equality only by id
    public override bool Equals(object obj)
    {
        return obj is Item item &&
               id == item.id;
    }

    public override int GetHashCode()
    {
        return id.GetHashCode();
    }
}