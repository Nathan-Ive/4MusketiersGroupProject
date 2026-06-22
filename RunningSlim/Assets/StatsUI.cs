using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [Header("References")]

    public StatsV1 playerStats;        // Link to the main stats script
    public TextMeshProUGUI distanceText; // Link to the distance text object
    public TextMeshProUGUI staminaText;  // Link to the stamina numbers (e.g. 100/100)
    public Slider staminaBar;          // Link to the UI slider bar

    void Update()
    {
        // Safety check to make sure the stats script is connected
        if (playerStats == null) return;

        // Updates the distance text on screen
        if (distanceText != null)
        {
            distanceText.text = "Distance: " + playerStats.GetFormattedDistance();
        }

        // Updates the slider bar and the stamina numbers
        if (staminaBar != null && staminaText != null)
        {
            float current = playerStats.GetStamina();
            float max = playerStats.GetMaxStamina();

            // Calculates the fill amount for the bar (current divided by max)
            staminaBar.value = current / max;

            // Updates the text to show whole numbers for stamina
            staminaText.text = current.ToString("F0") + " / " + max.ToString("F0");
        }
    }
}
