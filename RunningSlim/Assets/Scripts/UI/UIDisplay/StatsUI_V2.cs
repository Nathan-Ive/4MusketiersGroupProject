using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatsUI_V2 : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private StatsV2 _playerStats;
    [SerializeField] private TextMeshProUGUI _distanceText;
    [SerializeField] private TextMeshProUGUI _staminaText;
    [SerializeField] private Slider _staminaBar;

    void Update()
    {
        // Safety check
        if (_playerStats == null)
        {
            return;
        }

        // Update the distance text
        if (_distanceText != null)
        {
            _distanceText.text = "Distance: " + _playerStats.GetFormattedDistance();
        }

        // Update the bar and the number overlay
        if (_staminaBar != null && _staminaText != null)
        {
            float current = _playerStats.GetStamina();
            float max = _playerStats.GetMaxStamina();

            // Set bar fill (0 to 1)
            _staminaBar.value = current / max;

            // Set text (e.g., "85 / 100")
            _staminaText.text = current.ToString("F0") + " / " + max.ToString("F0");
        }
    }
}
