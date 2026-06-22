using System.Runtime.CompilerServices;
using TMPro;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Turns the distance run on the treadmill into a health level (Fat -> Fit) and decides when the game is won.
///
/// This is the script that ties the treadmill (StatsV2) together with the win conditions:
/// as the player runs, their fitness improves, and the game is won when the target distance is reached or the player becomes Fit.
/// </summary>
public class HealthLevelThresholds : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private StatsV2 _playerStats;   // The distance tracker

    [Header("Win Settings")]
    [SerializeField] private float _targetDistance = 100f;  // Meters needed to win by distance (the longer, backup path)
    [SerializeField] private float _metersToGetFit = 80f;   // Fitness metres for Fat -> Fit; Fit triggers at 80% = 64 m (the quick path)

    [Header("Read-only (shown for debugging)")]
    [SerializeField] private float _healthPercentage = 0.0f; // 0 = Fat, 1 = Fit
    [SerializeField] private HealthLevels _healthLevel = HealthLevels.Fat;
    [SerializeField] private string _healthLevelDisplay = "Fat";
    [SerializeField] private TMP_Text _healthLabel;

    private bool _hasWon = false;

    [Header("Events")]
    public UnityEvent OnWin;
    public UnityEvent<HealthLevels> OnHealthLevelChanged;

    // Let other scripts (UI) read the current health level
    public HealthLevels CurrentLevel => _healthLevel;
    public float HealthPercentage => _healthPercentage;
    public string HealthLevelDisplay => _healthLevelDisplay;

    void Update()
    {
        // Nothing to do if we have no treadmill to read, or the game is already won
        if (_playerStats == null || _hasWon)
            return;

        UpdateFitness();
        CheckWin();
    }

    /// <summary>
    /// Running improves fitness: the further the player has run, the closer to Fit they get.
    /// The health percentage is the distance run as a fraction of the distance needed to become Fit.
    /// </summary>
    private void UpdateFitness()
    {
        // Health/fitness reads the separate "health distance", which unhealthy food can
        // lower - so it stays independent of the total distance ran used for the distance win.
        float distance = _playerStats.GetHealthDistance();

        if (_metersToGetFit > 0f)
            _healthPercentage = Mathf.Clamp01(distance / _metersToGetFit);

        HealthLevels previousLevel = _healthLevel;
        HealthTracker();

        // Only announce a change when the tier actually moves, so listeners aren't spammed every frame
        if (_healthLevel != previousLevel)
            OnHealthLevelChanged?.Invoke(_healthLevel);
    }

    /// <summary>
    /// Sets the current health tier (and its display text) from the health percentage.
    /// The original if/else chain could never reach Fat for a 0 value.
    /// </summary>
    private void HealthTracker()
    {
        if (_healthPercentage >= 0.8f)
        {
            _healthLevel = HealthLevels.Fit;
            _healthLevelDisplay = "Fit";
        }
        else if (_healthPercentage >= 0.6f)
        {
            _healthLevel = HealthLevels.Healthy;
            _healthLevelDisplay = "Healthy";
        }
        else if (_healthPercentage >= 0.4f)
        {
            _healthLevel = HealthLevels.Average;
            _healthLevelDisplay = "Average";
        }
        else if (_healthPercentage >= 0.2f)
        {
            _healthLevel = HealthLevels.Unhealthy;
            _healthLevelDisplay = "Unhealthy";
        }
        else
        {
            _healthLevel = HealthLevels.Fat;
            _healthLevelDisplay = "Fat";
        }
        if (_healthLabel != null)
            _healthLabel.text = _healthLevelDisplay;
    }

    /// <summary>
    /// The player wins if they have run far enough OR become Fit (lost enough weight).
    /// </summary>
    private void CheckWin()
    {
        bool reachedDistance = _playerStats.GetDistance() >= _targetDistance;
        bool isFit = _healthLevel == HealthLevels.Fit;

        if (reachedDistance || isFit)
        {
            _hasWon = true;
            Debug.Log("You win!  (reached distance: " + reachedDistance + ", became Fit: " + isFit + ")");
            OnWin?.Invoke();
        }
    }
}
