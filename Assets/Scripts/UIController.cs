using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject pageOne;

    private ConfigReader _configReader;
    private DataConfig _config;

    private void Awake()
    {
        _configReader = gameObject.AddComponent<ConfigReader>();
        _config = _configReader.AppConfig;
    }

    private void Start()
    {
        SetCountText();
    }

    private void Update()
    {
        switch (pageOne.activeInHierarchy)
        {
            case true when IsButtonPressed():
                UpdateCount();
                pageOne.SetActive(false);
                break;
            case false when IsButtonPressed():
                pageOne.SetActive(true);
                break;
        }
    }

    private bool IsButtonPressed()
    {
        return Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1);
    }

    private void UpdateCount()
    {
        _config.AddCount();
        SetCountText();
        _configReader.Save();
    }

    private void SetCountText()
    {
        if (_config.count >= 1000) {
            if (_config.count % 1000 < 100)
            {
                countText.text = $"{_config.count / 1000} 0{_config.count % 1000}";
                return;
            }
            
            countText.text = $"{_config.count / 1000} {_config.count % 1000}";
            return;
        }
        
        countText.text = _config.count.ToString();
    }
}
