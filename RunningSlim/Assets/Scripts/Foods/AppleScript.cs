using UnityEngine;

 class AppleScript : FoodInheritance
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int appleStored = 0;
    override public void Eating() 
    {
        _getStats.AddStaminaFromMax(10);


    }

    public override void OnMouseDown()
    {
        if (_inKitchen.CookingTime(1))
        {
            _foodStash.AddApple();
            Destroy(gameObject);
        }
        else
        {
            base.OnMouseDown();

        }
    }
}
