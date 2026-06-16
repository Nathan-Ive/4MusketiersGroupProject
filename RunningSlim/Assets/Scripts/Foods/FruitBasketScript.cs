using UnityEngine;

 class FruitBasketScript : FoodInheritance
{
    public override void Eating()
    {
        _getStats.IncreaseMaxStamina(8);


    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
    }


}
