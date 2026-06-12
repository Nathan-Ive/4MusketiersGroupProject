using UnityEngine;

public class StatsV1 : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private bool _trainingRoom = false;

    [Header("Tracked Data")]
    [SerializeField] private float _totalMeters = 0f;

    [Header("Settings")]
    [SerializeField] private float _metersPerSecond = 2.0f;
    [SerializeField] private float _stamina = 100f;
    [SerializeField] private float _staminaDrainRate = 5.0f;
    [SerializeField] private float _maxStamina = 100f;

    // Public method so the UI can read the stamina value
    public float GetStamina()
    {
        return _stamina;
    }

    // Public method so the UI can read the max stamina value
    public float GetMaxStamina()
    {
        return _maxStamina;
    }

    public string GetFormattedDistance()
    {
        float kilometers = _totalMeters / 1000f;

        if (kilometers >= 1)
        {
            return kilometers.ToString("F2") + " km";
        }
        else
        {
            return _totalMeters.ToString("F1") + " m";
        }
    }

    void Update()
    {
        if (_trainingRoom == true)
        {
            if (_stamina >= 0)
            {
                Debug.Log("You snooze you lose.");
            }
            TrackDistance();
        }
    }

    private void TrackDistance()
    {
        _totalMeters += _metersPerSecond * Time.deltaTime;
        _stamina -= _staminaDrainRate * Time.deltaTime;

        if (_stamina < 0)
        {
            _stamina = 0;
        }
    }

    public void ResetStats()
    {
        _totalMeters = 0f;
        _stamina = _maxStamina;
    }
}
