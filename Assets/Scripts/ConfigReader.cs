using System.IO;
using UnityEngine;

public class ConfigReader : MonoBehaviour
{
    public DataConfig AppConfig { get; private set; }

    private static string _configPath;
    
    public ConfigReader()
    {
        _configPath = Application.streamingAssetsPath + "/config.json";
        Debug.Log(_configPath);
        var fileContents = File.ReadAllText(_configPath);
        AppConfig = JsonUtility.FromJson<DataConfig>(fileContents);
    }

    public void Save()
    {
        File.WriteAllText(_configPath, JsonUtility.ToJson(AppConfig));
    }
}