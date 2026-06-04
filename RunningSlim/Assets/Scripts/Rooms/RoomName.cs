using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;


/// <summary>
/// This script will always be attached to a room to always make sure the CurrentRoomHandler has a name to reference.
/// 
/// If this script isn't attached to a room, it will not be considered a room by both the RoomHandler and RoomSwapper scripts.
/// 
/// The intent is that this ends up being a list of names to be displayed that can be added on to through the CurrentRoomHandler script.
/// </summary>
public class RoomName : MonoBehaviour
{
    public string roomName;
}
