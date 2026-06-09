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
        if (playerStats == null) return;

        if (distanceText != null)
        {
            distanceText.text = "Distance: " + playerStats.GetFormattedDistance();
        }

        if (staminaBar != null)
        {
            // Calling the public getter methods to get the private values
            float currentStamina = playerStats.GetStamina();
            float maxStamina = playerStats.GetMaxStamina();

            staminaBar.value = currentStamina / maxStamina;
        }
    }
}
