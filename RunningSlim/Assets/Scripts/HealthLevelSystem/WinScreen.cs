using UnityEngine;
using TMPro;


/// <summary>
/// A simple win screen: shows a "You Win!" message and freezes the game.
///
/// It does nothing on its own, you need another game object to call Show() when the player wins. 
/// The intended hook-up is HealthLevelThresholds' OnWin event, which fires the moment the player reaches the target distance or becomes Fit.
/// </summary>
public class WinScreen : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _winPanel;   // The panel to switch on when the player wins
    [SerializeField] private TMP_Text _winText;

    [Header("Settings")]
    [SerializeField] private string _message = "You Win!";
    [SerializeField] private bool _freezeGame = true; // Stops all gameplay

    void Awake()
    {
        // Gameplay should run normally until a win happens, and time must run
        // normally in case a previous play session left it frozen.
        if (_winPanel != null)
            _winPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    /// <summary>
    /// Shows the win screen and (optionally) freezes the whole game.
    /// </summary>
    public void Show()
    {
        if (_winText != null)
            _winText.text = _message;

        if (_winPanel != null)
            _winPanel.SetActive(true);

        // Setting timeScale to 0 stops every Update-driven system at once:
        // the treadmill stops counting distance, stamina stops draining, and room input no longer advances.
        if (_freezeGame)
            Time.timeScale = 0f;
    }
}
