using UnityEngine;


/// <summary>
/// Restricts treadmill running to the training room.
///
/// The treadmill (StatsV2) counts distance and drains stamina whenever its TrainingRoom flag is on.
/// This script makes sure that flag can only be on while the player is actually in the training room. 
/// 
/// The "start/stop running" button calls ToggleTraining(), and the moment the player leaves the training room, 
/// running is forced off so they can't keep training while in another room.
/// </summary>
public class TrainingRoomGate : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private StatsV2 _playerStats;
    [SerializeField] private CurrentRoomHandler _roomHandler;

    [Header("Settings")]
    [SerializeField] private int _trainingRoomIndex = 0; // Which room in the list is the training room

    [Tooltip("Optional: the invisible start/stop-running button. It is shown only while in the training room.")]
    [SerializeField] private GameObject _trainingButton;

    // True only while the current room is the training room
    private bool InTrainingRoom
    {
        get { return _roomHandler != null && _roomHandler.currentIndex == _trainingRoomIndex; }
    }

    void Update()
    {
        if (_playerStats == null)
            return;

        bool inRoom = InTrainingRoom;

        // If the player leaves the training room while running, stop running.
        if (!inRoom && _playerStats.TrainingRoom)
            _playerStats.TrainingRoom = false;

        // Show the running button only inside the training room.
        if (_trainingButton != null && _trainingButton.activeSelf != inRoom)
            _trainingButton.SetActive(inRoom);
    }

    /// <summary>
    /// Starts or stops running.
    /// Only turns running on while the player is in the training room.
    /// </summary>
    public void ToggleTraining()
    {
        if (_playerStats == null)
            return;

        if (!InTrainingRoom)
        {
            _playerStats.TrainingRoom = false;
            return;
        }

        _playerStats.TrainingRoom = !_playerStats.TrainingRoom;
    }

    /// <summary>Forces running on.</summary>
    public void StartTraining()
    {
        if (_playerStats != null && InTrainingRoom)
            _playerStats.TrainingRoom = true;
    }

    /// <summary>Forces running off, wherever the player is.</summary>
    public void StopTraining()
    {
        if (_playerStats != null)
            _playerStats.TrainingRoom = false;
    }
}
