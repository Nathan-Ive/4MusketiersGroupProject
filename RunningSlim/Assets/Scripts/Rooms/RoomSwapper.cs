using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using TMPro;


/// <summary>
/// RoomSwapper handles the camera, changing the coordinates of the camera to one of the other rooms.
/// 
/// The reason why this script will move the camera instead of activating and deactivating them 
/// is because I don't know how many rooms the game will have.
/// 
/// This script keeps track of the room's position and retreives a name from the room it is looking at.
/// It knows what room it's going to thanks to the CurrentRoomHandler script. Which this script references to keep track of the index numbers.
/// 
/// The coordinates it switches to is based on the index number of the Current Room in the CurrentRoomHandler.
/// 
/// The provided coordinates are handeled by the RoomBackground GameObjects.
/// </summary>


public class RoomSwapper : MonoBehaviour
{
    public CurrentRoomHandler roomHandler;
    public Camera mainCamera;
    public List<Transform> rooms;
    public TMP_Text roomNameLabel;


    /// <summary>
    /// This script references the name relating to the room connected to the current index number.
    /// It then changes the text to the room name, or "Unnamed Room" for rooms that don't have names, this is to prevent null exceptions and crashes.
    /// </summary>
    public void UpdateRoomName()
    {
        Transform current = rooms[roomHandler.currentIndex];
        RoomName nameComponent = current.GetComponent<RoomName>();

        if (nameComponent != null)
            roomNameLabel.text = nameComponent.roomName;
        else
            roomNameLabel.text = "Unnamed Room";
    }

    /// <summary>
    /// It changes all the vector 3 coordinates of the camera to match the "position" value of the "target".
    /// The "target" matches the value of the current room[index] value. After that, newPosition equates all of its values to the X, Y and Z of the room.
    /// It has the target so it's stored within this script first, it then has the newPosition so it has all the values for the camera.
    /// Finally, the Z axis of the "newPosition" variable is equated to the camera's Z position. 
    /// This is because if it didn't, the camera would be moved forward and not display the scene anymore.
    /// Finally, it updates the room name for the text display.
    /// </summary>
    public void SwapToCurrentRoom()
    {
        Transform target = rooms[roomHandler.currentIndex];

        Vector3 newPosition = target.position;
        newPosition.z = mainCamera.transform.position.z;

        mainCamera.transform.position = newPosition;

        UpdateRoomName();
    }

    /// <summary>
    /// This is the boolean that loops through the current room to check which index entry the room is currently in.
    /// It does this by referencing the currentIndex value from the CurrentRoomHandler.
    /// </summary>
    public void UpdateActiveRoom()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            bool isCurrent = (i == roomHandler.currentIndex);
            rooms[i].gameObject.SetActive(isCurrent);
        }
    }

    /// <summary>
    /// Triggers the function to go to the "next room" in the index, using the CurrentRoomHandler's NextRoom function.
    /// It then calls the SwapToCurrentRoom function to move the camera to its new position. 
    /// </summary>
    public void GoToNextRoom()
    {
        roomHandler.NextRoom(rooms.Count);
        SwapToCurrentRoom();
    }

    /// <summary>
    /// Does the opposite of the GoToNextRoom function. Using the CurrentRoomHandler's PreviousRoom function to decrease the index number.
    /// It then calls the SwapToCurrentRoom function to move the camera to its new position.
    /// </summary>
    public void GoToPreviousRoom()
    {
        roomHandler.PreviousRoom(rooms.Count);
        SwapToCurrentRoom();
    }

    /// <summary>
    /// Routes a direction (e.g. from the InputManager's OnDirectionPressed event) to the
    /// next/previous room. Right/up goes to the next room, left/down goes to the previous one.
    /// </summary>
    public void Navigate(Vector2Int direction)
    {
        if (direction.x > 0 || direction.y > 0)
            GoToNextRoom();
        else if (direction.x < 0 || direction.y < 0)
            GoToPreviousRoom();
    }




}