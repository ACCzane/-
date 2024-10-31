using System;
using System.Collections.Generic;
using System.IO;
using Baracuda.Monitoring;
using Newtonsoft.Json;
using UnityEngine;



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
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
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

    public List<(string, int)> furnitures = new();

    public List<PlacedFurniture> placedFurnitures = new();

    /// <summary>
    /// 用于将furnitures中的家具，根据id转移到placedFurnitures中，同时数量减少
    /// </summary>
    /// <param name="id"></param>
    public PlacedFurniture Transfer(string id, Vector3 pos)
    {
        var furnitureIndex = furnitures.FindIndex(f => f.Item1 == id);
        if (furnitureIndex == -1)
        {
            throw new Exception("存档中根本没有此家具");
        }
        else if (furnitures[furnitureIndex].Item2 > 1)
        {
            var furniture = furnitures[furnitureIndex];
            furnitures[furnitureIndex] = (furniture.Item1, furniture.Item2 - 1);
        }
        else if (furnitures[furnitureIndex].Item2 == 1)
        {
            furnitures.RemoveAt(furnitureIndex);
        }
        else
        {
            throw new Exception("Unexpected exception");
        }

        var pFurniture = new PlacedFurniture()
        {
            id = id,
            position = pos,
            status = 0
        };
        placedFurnitures.Add(pFurniture);
        return pFurniture;

    }

    /// <summary>
    /// 用于将placedFurnitures中的家具，根据id转移到furnitures中，同时数量增加
    /// </summary>
    public void RevertToStorage(PlacedFurniture placedFurniture)
    {
        placedFurnitures.Remove(placedFurniture);

        var furnitureIndex = furnitures.FindIndex(f => f.Item1 == placedFurniture.id);
        if (furnitureIndex == -1)
        {
            furnitures.Add((placedFurniture.id, 1));
        }
        else
        {
            var furniture = furnitures[furnitureIndex];
            furnitures[furnitureIndex] = (furniture.Item1, furniture.Item2 + 1);
        }
    }


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