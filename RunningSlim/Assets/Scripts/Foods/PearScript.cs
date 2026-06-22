using UnityEngine;

 class PearScript : FoodInheritance
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    override public void Eating()
    {
        _getStats.AddStaminaFromCurrent(60);


    }

    public override void OnMouseDown()
    {
        if (_inKitchen.CookingTime(1))
        {
            _foodStash.AddPear();
            Destroy(gameObject);
        }
        else
        {
            base.OnMouseDown();

        }
    }
}