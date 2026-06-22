using UnityEngine;

 class FruitBasketScript : FoodInheritance
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    override public void Eating()
    {
        _getStats.AddStaminaFromMax(15);
        _getStats.IncreaseMaxStamina(12);
        


    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
    }
}

