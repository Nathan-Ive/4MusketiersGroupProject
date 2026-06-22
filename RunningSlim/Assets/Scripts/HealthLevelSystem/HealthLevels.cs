using UnityEngine;
/// <summary>
/// The health levels the player can have.
/// A value that's kept track of for the player to visually change, and get certain debuffs.
/// Will be used in HealthLevelThresholds and similar scripts to attach a category to each level of health.
/// 
/// For the prototype "Fit" may be a win condition. If not that, it will be distance traveled.
/// </summary>
public enum HealthLevels
{
    Fat,
    Unhealthy,
    Average,
    Healthy,
    Fit
}
