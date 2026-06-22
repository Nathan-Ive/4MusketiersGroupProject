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
        base.OnMouseDown();
    }
}