using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [Header("References")]
    public StatsV1 playerStats;
    public TextMeshProUGUI distanceText;
    public Slider staminaBar;

    void Update()
    {
        // We check if playerStats exists so the game doesn't crash
        if (playerStats != null)
        {
            // You must use 'playerStats.' here to tell the code to look in your other script
            if (distanceText != null)
            {
                distanceText.text = "Distance: " + playerStats.GetFormattedDistance();
            }

            if (staminaBar != null)
            {
                // Same here, we are asking 'playerStats' for the stamina values
                float currentStamina = playerStats.GetStamina();
                float maxStamina = playerStats.GetMaxStamina();

                staminaBar.value = currentStamina / maxStamina;
            }
        }
    }
}
