using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [Header("References")]
<<<<<<< Updated upstream
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
=======
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
>>>>>>> Stashed changes
        }
    }
}
