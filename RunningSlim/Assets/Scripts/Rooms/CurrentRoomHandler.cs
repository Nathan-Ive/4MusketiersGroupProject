using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Unity.VisualScripting;



/// <summary>
/// The CurrentRoomHandler script is the script that keeps track of what room the player is currently in.
/// 
/// The intent of this script is to change the canvas text to the corresponding room based on the room name it receives from the room position.
/// 
/// There will have to be an aditional script that provides this one with the room names.
/// </summary>
public class CurrentRoomHandler : MonoBehaviour
{
    public int currentIndex = 0;


    /// <summary>
    /// Increases index number. Sets currentIndex to zero if the currentIndex goes higher than the roomCount value.
    /// </summary>
    /// <param name="roomCount">The amount of total rooms that exist in the index.</param>
    public void NextRoom(int roomCount)
    {
        currentIndex++;
        if (currentIndex >= roomCount)
            currentIndex = 0;
    }
    /// <summary>
    /// Decreases index number. Sets currentIndex to the highest index value (the last room in the index), if the currentIndex value is less than 0.
    /// </summary>=
    public void PreviousRoom(int roomCount)
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = roomCount - 1;
    }
}