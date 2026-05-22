using UnityEngine;



/// <summary>
/// RoomSwapper handles the camera, changing the coordinates of the camera to one of the other rooms.
/// 
/// The reason why this script will move the camera instead of activating and deactivating them 
/// is because I don't know how many rooms the game will have.
/// 
/// The intent is that each newly added room has coordinates, are of the same size, and the camera teleports to their location using this script.
/// Every added room will be placed in this script's GameObject and that will tell the camera where to go.
/// 
/// This script doesn't care about what room it goes to, and it doesn't care about what can be done in the room. 
/// It only switches the camera's position
/// </summary>
public class RoomSwapper
{
    
}
