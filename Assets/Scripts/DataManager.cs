using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public PlayerData data;
    public string file = "player";

    public void Save()
    {
        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json);
    }

    public void Load()
    {
        data = new PlayerData();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);
    }

    void WriteToFile(string file_name, string json)
    {
        string path = GetFilePath(file_name);
        FileStream filestream = new FileStream(path, FileMode.Create);

        using(StreamWriter writer = new StreamWriter(file_name))
        {
            writer.Write(json);
        }
    }

    string ReadFromFile(string file_name)
    {
        string path = GetFilePath(file_name);
        if(File.Exists(path))
        {
            using(StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.Log("FILE NOT FOUND 404");
        }

        return "";
    }

    private string GetFilePath(string file_name)
    {
        return Application.persistentDataPath + "/" + file_name;
    }

    void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            Save();
        }
    }
}
