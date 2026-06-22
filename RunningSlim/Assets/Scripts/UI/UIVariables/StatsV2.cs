using UnityEngine;

public class StatsV2 : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private bool _isTraining = false;

    [Header("Tracked Data")]
    [SerializeField] private float _totalMeters = 0f;   // The real, total distance ran (distance display + distance win)
    [SerializeField] private float _healthDistance = 0f; // "Fitness" distance for the health-level system; lowered by unhealthy food

    [Header("Settings")]
    [SerializeField] private float _metersPerSecond = 2.0f;
    [SerializeField] private float _stamina = 100f;
    [SerializeField] private float _staminaDrainRate = 5.0f;
    [SerializeField] private float _minStaminaDrainRate = 5.0f; // Floor that pears can reduce drain back down to
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

    // The real total distance ran, in metres (distance display + the distance win condition)
    public float GetDistance() => _totalMeters;

    // The "fitness" distance used by the health-level system. Rises as you run, falls when you eat unhealthy food.
    public float GetHealthDistance() => _healthDistance;

    // Lowers the fitness distance (e.g. eating unhealthy food), never below zero.
    public float ReduceHealthDistance(float amount)
    {
        _healthDistance -= amount;
        if (_healthDistance < 0f)
            _healthDistance = 0f;

        return _healthDistance;
    }

    // Raises the max stamina limit WITHOUT refilling current stamina (unlike IncreaseMaxStamina).
    public float RaiseMaxStamina(float amount)
    {
        _maxStamina += amount;
        return _maxStamina;
    }

    // Permanently increases how fast stamina drains while running (used by unhealthy food).
    public float IncreaseStaminaDrain(float amount)
    {
        _staminaDrainRate += amount;
        return _staminaDrainRate;
    }

    // Reduces stamina drain (e.g. a pear undoing junk food), never below the minimum.
    public float ReduceStaminaDrain(float amount)
    {
        _staminaDrainRate -= amount;
        if (_staminaDrainRate < _minStaminaDrainRate)
            _staminaDrainRate = _minStaminaDrainRate;

        return _staminaDrainRate;
    }

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
        float metres = _metersPerSecond * Time.deltaTime;
        _totalMeters += metres;     // real distance, only ever goes up
        _healthDistance += metres;  // fitness, can later be lowered by unhealthy food

        // Use the helper to drain stamina too
        ApplyStaminaChange(-_staminaDrainRate * Time.deltaTime);
    }

    public void ResetStats()
    {
        _totalMeters = 0f;
        _healthDistance = 0f;
        _stamina = _maxStamina;
    }
}
