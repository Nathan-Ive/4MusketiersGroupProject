using UnityEngine;

 class PearScript : FoodInheritance
{
    [SerializeField] private float _drainReduction = 5f; // Undoes junk food's drain increase, down to the minimum

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    override public void Eating()
    {
        _getStats.AddStaminaFromCurrent(60);
        _getStats.ReduceStaminaDrain(_drainReduction);
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