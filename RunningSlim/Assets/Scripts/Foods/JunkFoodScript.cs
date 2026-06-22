using UnityEngine;

/// <summary>
/// An unhealthy snack, designed as a TRAP. Eating it:
///   - raises the max stamina limit (tempting for endurance),
///   - recovers stamina (50% of max by default),
///   - lowers the player's fitness distance, so their health level drops, and
///   - permanently increases stamina drain.
///
/// The trap: the fitness loss puts the Fit win out of reach, while the rising drain
/// means eating it in excess (to stack max stamina) eventually burns stamina faster
/// than you can sustain - so the distance win slips away too. Fruit (apple/pear) is
/// the safe choice for actually winning.
/// Attach it to a food prefab the same way as AppleScript/PearScript (sprite + collider).
/// </summary>
class JunkFoodScript : FoodInheritance
{
    [SerializeField] private float _maxStaminaGain = 10f;      // Permanent max-stamina increase
    [SerializeField] private float _staminaRecoveryPercent = 50f; // % of max stamina restored
    [SerializeField] private float _fitnessLoss = 300f;        // Fitness distance removed (lowers health level)
    [SerializeField] private float _staminaDrainIncrease = 10f; // Permanent increase to how fast stamina drains

    public override void Eating()
    {
        // Raise the cap without auto-refilling, so the recovery below is actually meaningful.
        _getStats.RaiseMaxStamina(_maxStaminaGain);
        _getStats.AddStaminaFromMax(_staminaRecoveryPercent);
        _getStats.ReduceHealthDistance(_fitnessLoss);
        _getStats.IncreaseStaminaDrain(_staminaDrainIncrease);
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
    }
}
