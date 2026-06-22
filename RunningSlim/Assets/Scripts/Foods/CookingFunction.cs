using UnityEngine;

public class CookingFunction : MonoBehaviour
{
    private CurrentRoomHandler _inKitchen; 
    private void Start()
    {
        _inKitchen = FindAnyObjectByType<CurrentRoomHandler>();
    }
       public void Cooking()
    {
        if (_inKitchen.CookingTime(1))
        {

        }
    }
          

    
    
    }




