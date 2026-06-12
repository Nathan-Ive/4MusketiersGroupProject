using UnityEngine;

 class CucumberScript : FoodInheritance
{
    public override void Eating()
    {
        _getStats.MaxStamina += 4;
        Debug.Log("Max stamina:" + _getStats.MaxStamina);

    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
    }


}
