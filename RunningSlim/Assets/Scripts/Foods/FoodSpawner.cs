using UnityEngine;

/// <summary>
/// Spawns food items when its buttons are pressed - a simple, no-cost way to get food
/// so the game is actually beatable (you need fruit to keep stamina up while running).
///
/// The spawn buttons are only available in the kitchen: they are hidden and disabled
/// when the player is in any other room, mirroring how TrainingRoomGate handles the
/// training button.
///
/// Setup:
///   1. Put this on an ALWAYS-ACTIVE GameObject (e.g. a manager) - not on the button
///      panel itself, or it could not switch its own panel back on.
///   2. Drag the Apple, Pear and JunkFood/Pizza prefabs into the matching fields.
///   3. (Optional) Set Spawn Point to where food should appear; defaults to this object.
///   4. Link Room Handler (the CurrentRoomHandler used by RoomSwapper) and set
///      Kitchen Room Index to the kitchen's slot in the room list.
///   5. Put the three spawn buttons under one parent object and drag that parent into
///      Button Panel.
///   6. Hook each button's OnClick to SpawnApple / SpawnPear / SpawnJunkFood.
/// </summary>
public class FoodSpawner : MonoBehaviour
{
    [Header("Food Prefabs")]
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private GameObject _pearPrefab;
    [SerializeField] private GameObject _junkFoodPrefab;

    [Header("Where food appears")]
    [SerializeField] private Transform _spawnPoint;       // Defaults to this object's position if unset
    [SerializeField] private float _spawnScatter = 0.5f;  // Small random offset so items don't stack exactly

    [Header("Kitchen gating")]
    [SerializeField] private CurrentRoomHandler _roomHandler;
    [SerializeField] private int _kitchenRoomIndex = 1;   // Which room in the list is the kitchen
    [Tooltip("Parent object holding the spawn buttons. Shown only while in the kitchen.")]
    [SerializeField] private GameObject _buttonPanel;

    // True only while the current room is the kitchen
    private bool InKitchen
    {
        get { return _roomHandler != null && _roomHandler.currentIndex == _kitchenRoomIndex; }
    }

    void Update()
    {
        // Show the spawn buttons only inside the kitchen.
        if (_buttonPanel != null && _buttonPanel.activeSelf != InKitchen)
            _buttonPanel.SetActive(InKitchen);
    }

    // Hook these to the three buttons' OnClick events.
    public void SpawnApple() => Spawn(_applePrefab);
    public void SpawnPear() => Spawn(_pearPrefab);
    public void SpawnJunkFood() => Spawn(_junkFoodPrefab);

    private void Spawn(GameObject prefab)
    {
        // Spawning only works in the kitchen, even if a button is somehow triggered elsewhere.
        if (!InKitchen)
            return;

        if (prefab == null)
        {
            Debug.LogWarning("FoodSpawner: no prefab assigned for that button.");
            return;
        }

        Vector3 origin = _spawnPoint != null ? _spawnPoint.position : transform.position;
        Vector2 offset = Random.insideUnitCircle * _spawnScatter;
        Vector3 spawnPos = origin + new Vector3(offset.x, offset.y, 0f);

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}
