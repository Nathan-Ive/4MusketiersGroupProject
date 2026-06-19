using UnityEngine;

 class FruitBasket : FoodInheritance
{
    public override void Eating()
    {
        _getStats.MaxStamina += 12;
        Debug.Log("Max stamina:" + _getStats.MaxStamina);

    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
    }


}
