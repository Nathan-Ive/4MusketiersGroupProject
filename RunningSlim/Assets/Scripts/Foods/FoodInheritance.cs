using UnityEngine;

  abstract class FoodInheritance : MonoBehaviour //it's a parent class
{
    [SerializeField] private string _name;
    [SerializeField] private string _desc;
    //props best to use get set 
    protected StatsV2 _getStats;
    protected CurrentRoomHandler _inKitchen;
    protected GeneralFoodStash _foodStash;
    void Start()
    {
        _getStats = FindAnyObjectByType<StatsV2>();
    }
    public abstract void Eating();

     public virtual void OnMouseDown()
    {
        Eating();
        Destroy(gameObject);
    }
    //protected means that only the parent and child classes have acces to this

    
    // Update is called once per frame



    //a UI that's seprate from the food prefab that gets the component and displays the food name and description.
}
