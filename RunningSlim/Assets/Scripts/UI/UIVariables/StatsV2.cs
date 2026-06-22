using UnityEngine;

public class StatsV2 : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private bool _isTraining = false;

    [Header("Tracked Data")]
    [SerializeField] private float _totalMeters = 0f;

    [Header("Settings")]
    [SerializeField] private float _metersPerSecond = 2.0f;
    [SerializeField] private float _stamina = 100f;
    [SerializeField] private float _staminaDrainRate = 5.0f;
    [SerializeField] private float _maxStamina = 100f;

    // Public property for TrainingRoom so teammates can toggle it easily
    public bool TrainingRoom
    {
        get { return _isTraining; }
        set { _isTraining = value; }
    }

    // Getters for the UI
    public float GetStamina() => _stamina;
    public float GetMaxStamina() => _maxStamina;

    // Lets other scripts (e.g. the win-condition tracker) read the raw distance in metres
    public float GetDistance() => _totalMeters;

    // 1. Direct amount
    public float AddStamina(float amount)
    {
        return ApplyStaminaChange(amount);
    }

    // 2. Percentage of CURRENT stamina
    public float AddStaminaFromCurrent(float percent)
    {
        float amount = _stamina * (percent / 100f);
        return ApplyStaminaChange(amount);
    }

    // 3. Percentage of MAX stamina
    public float AddStaminaFromMax(float percent)
    {
        float amount = _maxStamina * (percent / 100f);
        return ApplyStaminaChange(amount);
    }

    // 4. Permanently increases the max stamina limit
    public float IncreaseMaxStamina(float amount)
    {
        _maxStamina += amount;

        // Optional: Refill current stamina to the new max
        _stamina = _maxStamina;

        return _maxStamina; // Returns the new total limit
    }

    // Private helper to keep code DRY (Don't Repeat Yourself)
    private float ApplyStaminaChange(float amount)
    {
        _stamina += amount;

        if (_stamina > _maxStamina)
        {
            _stamina = _maxStamina;
        }

        if (_stamina < 0)
        {
            _stamina = 0;
        }

        return _stamina;
    }

    public string GetFormattedDistance()
    {
        float kilometers = _totalMeters / 1000f;

        if (kilometers >= 1)
        {
            return kilometers.ToString("F2") + " km";
        }

        return _totalMeters.ToString("F1") + " m";
    }

    void Update()
    {
        // Only track if toggle is on and we have stamina left
        if (_isTraining && _stamina > 0)
        {
            TrackDistance();
        }
    }

    private void TrackDistance()
    {
        _totalMeters += _metersPerSecond * Time.deltaTime;

        // Use the helper to drain stamina too
        ApplyStaminaChange(-_staminaDrainRate * Time.deltaTime);
    }

    public void ResetStats()
    {
        _totalMeters = 0f;
        _stamina = _maxStamina;
    }
}
