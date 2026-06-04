using UnityEngine;

public class StatsV1 : MonoBehaviour
{
    [Header("State")]
    [Tooltip("Toggle this to start/stop counting distance.")]
    public bool TrainingRoom = false;

    [Header("Tracked Data")]
    [SerializeField] private float totalMeters = 0f;

    [Header("Settings")]
    public float metersPerSecond = 2.0f;
    public float stamina = 100f;
    public float staminaDrainRate = 5.0f;
    public float maxStamina = 100f;

    // Returns the distance as a string for UI display
    public string GetFormattedDistance()
    {
        float kilometers = totalMeters / 1000f;

        if (kilometers >= 1)
        {
            // Returns kilometers with 2 decimal places
            return kilometers.ToString("F2") + " km";
        }
        else
        {
            // Returns meters with 1 decimal place
            return totalMeters.ToString("F1") + " m";
        }
    }

    void Update()
    {
        // Only run the logic if the player is in the training room and has stamina
        if (TrainingRoom == true)
        {
            if (stamina > 0)
            {
                TrackDistance();
            }
        }
    }

    private void TrackDistance()
    {
        // Add to total distance based on time passed
        totalMeters += metersPerSecond * Time.deltaTime;

        // Reduce stamina over time
        stamina -= staminaDrainRate * Time.deltaTime;

        // Prevent stamina from dropping below zero
        if (stamina < 0)
        {
            stamina = 0;
        }
    }

    public void ResetStats()
    {
        totalMeters = 0f;
        stamina = maxStamina;
    }
}
