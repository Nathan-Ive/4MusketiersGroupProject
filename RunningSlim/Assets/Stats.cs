using UnityEngine;

public class Stats : MonoBehaviour
{
    //UNITY SETTINGS
    [Header("State")]
    [Tooltip("Toggle this to start/stop counting distance.")]
    public bool TrainingRoom = false;

    [Header("Tracked Data")]
    [SerializeField] private float totalMeters = 0f;

    [Header("Settings")]
    [Tooltip("How many meters are added per second while training")]
    //Speed at which the distance increases while in the training room. Adjust as needed.
    public float metersPerSecond = 2.0f;
    [Tooltip("How much stamina the player has")]
    public float stamina = 100f;
    //UNITY SETTINGS END

    //UI PROPERTIES
    public float TotalMeters => totalMeters;
    public float TotalKilometers => totalMeters / 1000f;
    public string FormattedDistance => TotalKilometers >= 1
        ? $"{TotalKilometers:F2} km"
        : $"{totalMeters:F1} m";
    //UI PROPERTIES END

    //BOOL
    void Update()
    {
        if (TrainingRoom)
        {
            TrackDistance();
        }
    }
    //METHODS
    private void TrackDistance()
    {
        //Calculate distance based on time and speed
        totalMeters += metersPerSecond * Time.deltaTime;
    }

    public void ResetStats()
    {
        totalMeters = 0f;
        stamina = 100f;
    }
}
