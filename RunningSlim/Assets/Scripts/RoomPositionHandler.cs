using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;


/// <summary>
/// This script handles providing the other Room scripts with a position for the camera to teleport to.
/// 
/// While pulling the transform of an object and giving it to the camera directly is possible, 
/// there are some objects that have their origin point on the corner of the object itself.
/// 
/// These cases, and by extension all cases, a script like this, that provides a center point for each room, 
/// is smarter to use than the default Transform Position provided by Unity.
/// 
/// Attach this script to a game object, preferably a room. And provide it with X and Y coordinates, optionally Z. 
/// Afterwards this script will use those values to provide to another script. 
/// Preferably as reference for the script that changes the camera's Transform Position.
/// </summary>

public class RoomPositionHandler : MonoBehaviour
{
    //Subject to change. I'm still thinking about if three values like this actually feed Vector3's properly.
    [Header("Room Positions")]
    public float roomXPosition;
    public float roomYPosition;
    public float roomZPosition;

    public Transform target;


    void cameraTeleport() 
    {
        if (target == null) 
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            //targetPos = Vector3.Lerp(transform.position, targetPos);

        }


        //transform.position = ...;
    }


}
