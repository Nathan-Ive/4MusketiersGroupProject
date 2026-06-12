using UnityEngine;

public class StatsV1 : MonoBehaviour
{
    // These variables show up in the Unity Inspector
    [Header("State")]
    [SerializeField] private bool _trainingRoom = false; // Controls if distance should be counting

    [Header("Tracked Data")]
    [SerializeField] private float _totalMeters = 0f; // Stores the total distance covered

    [Header("Settings")]
    [SerializeField] private float _metersPerSecond = 2.0f; // How fast distance increases
    [SerializeField] private float _stamina = 100f;         // Current stamina amount
    [SerializeField] private float _staminaDrainRate = 5.0f; // How fast stamina drops
    [SerializeField] private float _maxStamina = 100f;      // The starting/max stamina

    // These functions allow the UI script to see the private values
    public float GetStamina()
    {
        return _stamina;
    }

    public float GetMaxStamina()
    {
        return _maxStamina;
    }

    // Turns the meter count into a readable text format (meters or kilometers)
    public string GetFormattedDistance()
    {
        float kilometers = _totalMeters / 1000f;

        if (kilometers >= 1)
        {
            // Shows 2 decimal places for km
            return kilometers.ToString("F2") + " km";
        }
        else
        {
            // Shows 1 decimal place for meters
            return _totalMeters.ToString("F1") + " m";
        }
    }
    public void AddStamina(float amount)
    {
        _stamina += amount;

        // Make sure stamina doesn't go over the max
        if (_stamina > _maxStamina)
        {
            _stamina = _maxStamina;
        }
    }

    void Update()
    {
        // Only runs the training logic if the toggle is on and stamina is above zero
        if (_trainingRoom == true)
        {
            if (_stamina > 0)
            {
                TrackDistance();
            }
        }
    }

    private void TrackDistance()
    {
        // Increases distance based on time passed since the last frame
        _totalMeters += _metersPerSecond * Time.deltaTime;

        // Decreases stamina based on the drain rate
        _stamina -= _staminaDrainRate * Time.deltaTime;

        // Makes sure stamina doesn't become a negative number
        if (_stamina < 0)
        {
            _stamina = 0;
        }
    }

    // A simple function to wipe progress and refill stamina
    public void ResetStats()
    {
        _totalMeters = 0f;
        _stamina = _maxStamina;
    }
}
