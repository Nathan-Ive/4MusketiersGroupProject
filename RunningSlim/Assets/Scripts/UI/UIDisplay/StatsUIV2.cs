using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatsUIV2 : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private StatsV2 _playerStats;
    [SerializeField] private TextMeshProUGUI _distanceText;
    [SerializeField] private TextMeshProUGUI _staminaText;

    [Header("Bar Settings")]
    [SerializeField] private RectTransform _barBackgroundRect;
    [SerializeField] private Image _staminaFillImage;
    [SerializeField] private float _widthPerStaminaUnit = 2f; // How many pixels wide 1 stamina point is

    void Update()
    {
        if (_playerStats == null) return;

        // 1. Update Distance Text
        if (_distanceText != null)
        {
            _distanceText.text = "Distance: " + _playerStats.GetFormattedDistance();
        }

        // 2. Update Stamina Logic
        float current = _playerStats.GetStamina();
        float max = _playerStats.GetMaxStamina();

        // Update the physical width of the bar based on Max Stamina
        if (_barBackgroundRect != null)
        {
            float targetWidth = max * _widthPerStaminaUnit;
            _barBackgroundRect.sizeDelta = new Vector2(targetWidth, _barBackgroundRect.sizeDelta.y);
        }

        // Update the fill amount (0 to 1)
        if (_staminaFillImage != null)
        {
            _staminaFillImage.fillAmount = current / max;
        }

        // Update the text overlay
        if (_staminaText != null)
        {
            _staminaText.text = current.ToString("F0") + " / " + max.ToString("F0");
        }
    }
}
