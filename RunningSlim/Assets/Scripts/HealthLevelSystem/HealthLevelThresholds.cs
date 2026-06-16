using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// Percentage thresholds for health levels.
/// Intended to be used on a "player" gameObject so it can keep track of the player's health.
/// 
/// Dictates and keeps track of what level of health the player is at.
/// </summary>
public class HealthLevelThresholds
{
    private double _healthPercentage = 0.0f;
    private HealthLevels _healthLevel;

    private void HealthTracker() 
    {
        if (_healthPercentage == 0.0f && _healthPercentage <= 0.2f) 
        {
            _healthLevel = HealthLevels.Fat;
        }
        else if (_healthPercentage >= 0.2f && _healthPercentage <= 0.4f)
        {
            _healthLevel = HealthLevels.Unhealthy;
        }
        else if (_healthPercentage >= 0.4f && _healthPercentage <= 0.6f)
        {
            _healthLevel = HealthLevels.Average;
        }
        else if (_healthPercentage >= 0.6f && _healthPercentage <= 0.8f)
        {
            _healthLevel = HealthLevels.Healthy;
        }
        else if (_healthPercentage >= 0.8f && _healthPercentage <= 1.0f)
        {
            _healthLevel = HealthLevels.Fit;
        }
    }



}