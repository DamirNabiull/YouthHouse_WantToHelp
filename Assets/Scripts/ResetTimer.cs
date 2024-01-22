using UnityEngine;

public class ResetTimer : MonoBehaviour
{
    public GameObject subscriber;

    private float _lastUpdateTime = 0;
    private float _restartTime;
    private bool _countTime = false;

    private void Start()
    {
        _restartTime = 40;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || IsButtonPressed())
        {
            Reset();
        }

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Reset();
            }
        }

        if (Time.time - _lastUpdateTime > _restartTime && _countTime)
        {
            _countTime = false;
            Notify();
        }
    }

    private bool IsButtonPressed()
    {
        return Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1);
    }

    private void Reset()
    {
        _countTime = true;
        _lastUpdateTime = Time.time;
    }

    private void Notify()
    {
        subscriber.SetActive(true);
    }
}