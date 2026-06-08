using UnityEngine;

abstract class AppleScript : FoodInheritance
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    override public void Eating() 
    {
        _getStats.Stamina +=  (_getStats.MaxStamina / 10);
       Debug.Log(_getStats.Stamina);
    }
}
