using UnityEngine;

public class StatsV1 : MonoBehaviour
{

    [Header("State")]
    [Tooltip("Toggle this to start/stop counting distance.")]
    [SerializeField]  private bool _TrainingRoom = false;

    [Header("Tracked Data")]
    [SerializeField] private float _totalMeters = 0f;

    [Header("Settings")]
    [SerializeField] private float _metersPerSecond = 2.0f;
    [SerializeField] private float _stamina = 100f;
    [SerializeField] private float _staminaDrainRate = 5.0f;
    [SerializeField] private float _maxStamina = 100f;


    public float Stamina
    {
        get
        {
            return _stamina;
        }
        set { if(_stamina != _maxStamina)
            {
            } 
        }

    }
    public float MaxStamina
    {
        get
        {
            return _maxStamina;
        }
        set
        {
            if (_maxStamina != 0f)
            {
            }
        }
    }
    // Returns the distance as a string for UI display
    public string GetFormattedDistance()
    {
        float kilometers = _totalMeters / 1000f;

        if (kilometers >= 1)
        {
            // Returns kilometers with 2 decimal places
            return kilometers.ToString("F2") + " km";
        }
        else
        {
            // Returns meters with 1 decimal place
            return _totalMeters.ToString("F1") + " m";
        }

    }

    void Update()
    {
        // Only run the logic if the player is in the training room and has stamina
        if (_TrainingRoom == true)
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
        // Add to total distance based on time passed
        _totalMeters += _metersPerSecond * Time.deltaTime;

        // Reduce stamina over time
        _stamina -= _staminaDrainRate * Time.deltaTime;

        // Prevent stamina from dropping below zero
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
