using UnityEngine;

 class AppleScript : FoodInheritance
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    override public void Eating() 
    {
        _getStats.AddStaminaFromMax(10);


    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
    }
}
